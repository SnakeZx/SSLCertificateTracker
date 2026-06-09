using SSLCertificateTracker.Model;
using SSLCertificateTracker.Services;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace SSLCertificateTracker.Controllers
{
    public class Controller
    {

        private readonly MainForm _view;
        private readonly AddSiteForm? _UserInputView;

        private readonly CertificateModel _model;

        private readonly CertificateService? _certificateService = new ();
        private readonly FileService _fileService = new ();

        private readonly BindingList<CertificateModel> _list;

        private readonly int port = 443;

        private X509Certificate2 _RawCertData = new ();


        public Controller(MainForm view, CertificateModel model)
        {
            _view = view;

            _model = model;

            _list = new BindingList<CertificateModel> ();

            _view.SetDataSource(_list);

            _view.OnAddNewSiteClick += ShowAddNewSite;

        }

        private void ShowAddNewSite()
        {
            using AddSiteForm _UserInputView = new ();
            _UserInputView.OnUserInputConfirm += GetCertificateData;
            

            //_UserInputView.OnConfirmSave += HandleSaveRequest;

            if (_UserInputView.ShowDialog(_view) != DialogResult.OK)
            {
                _UserInputView.OnUserInputConfirm -= GetCertificateData;
                return;
            }
            _UserInputView.OnUserInputConfirm -= GetCertificateData;
        }

        private async void GetCertificateData(string userInput)
        {
            CertificateModel newResource = new CertificateModel ();

            try
            {


                bool success = newResource.TryBuildUri(userInput);

                if (success && !HostNameExists(newResource.ComputedUri.Host))
                {
                        _RawCertData = await _certificateService.WebConnectAsync(newResource.ComputedUri.Host, port);

                        newResource.HostName = newResource.ComputedUri.Host;
                        newResource.LastIssuer = newResource.ExtractIssuer(_RawCertData.Issuer);
                        newResource.LastExpiryUtc = _RawCertData.NotAfter;
                        newResource.Status = newResource.GetStatus();
                        _list.Add(newResource);
                }
                else
                {
                    MessageBox.Show($"This website: {newResource.ComputedUri.Host} is already being tracked.", "Already Tracked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex) 
            { 
            
            }
        }


        private bool HostNameExists(string hostname)
        {
            bool exists = false;

            foreach (CertificateModel modelList in _list) 
            { 
                if(string.Equals(modelList.HostName, hostname, StringComparison.OrdinalIgnoreCase))
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }


        private async void HandleSaveRequest()
        {
            await _fileService.SaveAsync<CertificateModel>("sites.json", _list);
        }



    }
}
