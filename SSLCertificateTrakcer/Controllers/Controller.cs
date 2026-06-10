using SSLCertificateTracker.Model;
using SSLCertificateTracker.Services;
using System.ComponentModel;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace SSLCertificateTracker.Controllers
{
    public class Controller
    {

        private readonly MainForm _view;

        private readonly CertificateModel _model;

        private readonly CertificateService? _certificateService = new ();
        private readonly FileService _fileService = new ();

        private readonly BindingList<CertificateModel> _list;

        private readonly int port = 443;


        public Controller(MainForm view, CertificateModel model)
        {
            _view = view;

            _model = model;

            _list = new BindingList<CertificateModel> ();

            _view.SetDataSource(_list);

            _view.OnMainFormLoad += LoadDataRequest;
            _view.OnMainFormClose += SaveListToJson;

            _view.OnAddNewSiteClick += ShowAddNewSite;

            _view.OnRemoveClick += RemoveSelectedItem;

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

                bool exists = HostNameCheck(newResource.ComputedUri.Host);

                if (success && !exists)
                {
                        var _RawCertData = await _certificateService.WebConnectAsync(newResource.ComputedUri.Host, port);


                        newResource.HostName = newResource.ComputedUri.Host;
                        newResource.LastIssuer = newResource.ExtractIssuer(_RawCertData.Issuer);
                        newResource.LastExpiryUtc = _RawCertData.NotAfter;
                        newResource.Status = newResource.GetStatus();
                        _list.Add(newResource);
                        
                        SaveListToJson();
                }
                else
                {
                    MessageBox.Show($"This website: {newResource.ComputedUri.Host} is already being tracked.", "Already Tracked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (SocketException ex) 
            {
                newResource.HostName = userInput;
                newResource.Status = newResource.SetError(ex.);
                _list.Add(newResource);
            }
        }


        private bool HostNameCheck(string hostname)
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


        private void RemoveSelectedItem(int index)
        {
            _list.RemoveAt(index);
            SaveListToJson();
        }


        private async void SaveListToJson()
        {
            await _fileService.SaveAsync(_list);
        }

        private async void LoadDataRequest()
        {
          var temp = await _fileService.GetAllAsync();

            _list.Clear();

            foreach(var item in temp) 
            {
                item.Status = "Fetching....";
                _list.Add(item);
            }

        }

        private async void RefreshData()
        {

        }


    }
}
