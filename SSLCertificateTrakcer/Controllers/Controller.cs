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

            _view.OnRefreshSelectedClick += UpdateCertificateData;
            _view.OnRefreshAllClick += UpdateAllData;

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
                    _view.FormatRows(_list.IndexOf(newResource));

                    SaveListToJson();
                    _view.UpdateRowcount(_list.Count);
                }
                else
                {
                    MessageBox.Show($"This website: {newResource.ComputedUri.Host} is already being tracked.", "Already Tracked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                newResource.HostName = userInput;
                newResource.Status = newResource.SetError();
                _list.Add(newResource);
                _view.FormatRows(_list.IndexOf(newResource));
                _view.SetErrorToolTip(_list.IndexOf(newResource), ex.Message);
                _view.UpdateRowcount(_list.Count);
            }
        }


        private async void UpdateAllData()
        {
            foreach (var item in _list)
            {
                UpdateCertificateData(_list.IndexOf(item));
            }
            _view.UpdateRowcount(_list.Count);
        }

        private async void UpdateCertificateData(int index)
        {
            string savedHost = _list[index].HostName;

            CertificateModel newResource = new CertificateModel();

            try
            {

                _list[index].Status = "Fetching....";

                var _RawCertData = await _certificateService.WebConnectAsync(savedHost, port);


                newResource.HostName = savedHost;
                newResource.LastIssuer = newResource.ExtractIssuer(_RawCertData.Issuer);
                newResource.LastExpiryUtc = _RawCertData.NotAfter;
                newResource.Status = newResource.GetStatus();

                _list.RemoveAt(index);
                _list.Insert(index, newResource);
                
                SaveListToJson();
                _view.FormatRows(_list.IndexOf(newResource));
                
                _view.UpdateRowcount(_list.Count);
            }
            catch (Exception ex)
            {
                newResource.HostName = savedHost;
                newResource.Status = newResource.SetError();
                _list.RemoveAt(index);
                _list.Insert(index, newResource);
                _view.FormatRows(_list.IndexOf(newResource));
                _view.SetErrorToolTip(index, ex.Message);
            }
        }

        //Checks if the userinput hostname is already in the list. returns true if its found in the list.;
        private bool HostNameCheck(string hostname)
        {
            bool exists = false;

            foreach (CertificateModel modelList in _list)
            {
                if (string.Equals(modelList.HostName, hostname, StringComparison.OrdinalIgnoreCase))
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        //Removes Selected Row from the list.
        private async void RemoveSelectedItem(int index)
        {
            var result = MessageBox.Show($"Would you like to stop tracking {_list[index].HostName}?", "Are You Sure?", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            _list.RemoveAt(index);
            _view.UpdateRowcount(_list.Count);
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
                UpdateCertificateData(_list.IndexOf(item));
            }
            _view.UpdateRowcount(_list.Count);

        }

    }
}
