using SSLCertificateTracker.Model;
using SSLCertificateTracker.Services;
using SSLCertificateTracker.Subclass;
using System.Security.Cryptography.X509Certificates;


namespace SSLCertificateTracker.Controllers
{
    public class Controller
    {

        private readonly MainForm _view;

        private readonly CertificateModel _model;

        private readonly CertificateService? _certificateService = new ();
        private readonly FileService _fileService = new ();

        private readonly SortableBindingList<CertificateModel> _list;

        private readonly int port = 443;


        public Controller(MainForm view, CertificateModel model)
        {
            _view = view;

            _model = model;

            _list = new SortableBindingList<CertificateModel> ();

            _view.SetDataSource(_list);

            _view.OnMainFormLoad += LoadDataRequest;
            _view.OnMainFormClose += SaveListToJson;

            _view.OnAddNewSiteClick += ShowAddNewSite;
            _view.OnRemoveClick += RemoveSelectedItem;

            _view.OnRefreshSelectedClick += UpdateCertificateData;
            _view.OnRefreshAllClick += UpdateAllData;

            _view.OnCellDoubleClick += ShowCertificateData;

        }
        //Creates addSiteForm to take in user input and return the user input for the Get.
        private void ShowAddNewSite()
        {
            using AddSiteForm _UserInputView = new ();

            _UserInputView.OnUserInputConfirm += GetCertificateData;

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

                    //Creates new certificate model for the view to display 
                    newResource.rawCertificate = _RawCertData;
                    newResource.HostName = newResource.ComputedUri.Host;
                    newResource.LastIssuer = newResource.ExtractIssuer(_RawCertData.Issuer);
                    newResource.LastExpiryUtc = _RawCertData.NotAfter;
                    newResource.Status = newResource.GetStatus();
                    _list.Add(newResource);
                    SaveListToJson();

                    _view.UpdateRowcount(_list.Count);
                    _view.UpdateLastRefresh(newResource.LastCheckedUtc);
                }
                else
                {
                    //prompt user for a choice to add another site. If yes a new add site form box appears.
                    var result = MessageBox.Show($"This website: {newResource.ComputedUri.Host} is already being tracked.\nWould you like to track a different host?", "Already Tracked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (result == DialogResult.Yes) 
                        { ShowAddNewSite(); }
                    return;
                }

            }
            catch (Exception ex)
            {
                //If there is an error a new row is still made with a tooltip in the status column for what the error is.
                newResource.HostName = userInput;
                newResource.Status = newResource.SetErrorStatus();
                newResource.LastErrorMessage = ex.Message;

                _list.Add(newResource);

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

        //Updates certificate and skips the check for duplicate since we need to skip as we are removing and updating with new information.
        private async void UpdateCertificateData(int index)
        {
            if(index < 0) {  return; }
            string savedHost = _list[index].HostName;

            CertificateModel newResource = new CertificateModel();

            try
            {
                _list[index].Status = "Fetching....";

                var _RawCertData = await _certificateService.WebConnectAsync(savedHost, port);

                newResource.rawCertificate = _RawCertData;
                newResource.HostName = savedHost;
                newResource.LastIssuer = newResource.ExtractIssuer(_RawCertData.Issuer);
                newResource.LastExpiryUtc = _RawCertData.NotAfter;
                newResource.Status = newResource.GetStatus();

                if (index < 0) { return; }
                _list.RemoveAt(index);
                _list.Insert(index, newResource);
                
                _view.UpdateRowcount(_list.Count);
                _view.UpdateLastRefresh(newResource.LastCheckedUtc);
            }
            catch (Exception ex)
            {
                //checks for deletion during an update request.
                //TODO: Show Notify User that a row may was deleted while updating.
                if (index < 0) { MessageBox.Show("A row was deleted while Feteching certificate information and will not be added to the list.","Row Deleted",MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                newResource.HostName = savedHost;
                newResource.Status = newResource.SetErrorStatus();
                newResource.LastErrorMessage = ex.Message;

                _list.RemoveAt(index);
                _list.Insert(index, newResource);
                _view.SetErrorToolTip(_list.IndexOf(newResource), ex.Message);
            }
        }

        //Checks if the userinput hostname is already in the list. returns true if its found in the list;
        private bool HostNameCheck(string hostname)
        {
            bool exists = false;

            foreach (var item in _list)
            {
                if (string.Equals(item.HostName, hostname, StringComparison.OrdinalIgnoreCase))
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
            SaveListToJson();
        }

        private void ShowCertificateData(int index)
        {
            bool isOpen = false;

            if(_list[index].rawCertificate == null)
            {
                MessageBox.Show("The Selected row does not have a valid certificate to view. Please select another row or refresh the list if you think this is a mistake.","Certificate Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isOpen == false)
            {
                X509Certificate2UI.DisplayCertificate(_list[index].rawCertificate);

            }
            else
            {
                MessageBox.Show("Only one certificate can be viewed at a time.", "Too many requested", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

    }
}
