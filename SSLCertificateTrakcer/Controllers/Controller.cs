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

        private string _rawInput;
        private Uri ComputedUri;

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

            _view.OnRefreshSelectedClick += UpdateSelectedRowData;
            _view.OnRefreshAllClick += UpdateAllData;

            _view.OnCellDoubleClick += ShowCertificateData;

            _view.ErrorMesssageTooltip += SetErrorToolTip;

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
            CertificateModel newResource = new CertificateModel();

            try
            {
                bool success = TryBuildUri(userInput);

                bool exists = HostNameCheck(ComputedUri.Host);

                if (success && !exists)
                {

                    var _RawData = await _certificateService.WebConnectAsync(ComputedUri.Host, port);

                    //Creates new certificate model for the view to display 
                    newResource.rawCertificate = _RawData;
                    newResource.HostName = ComputedUri.Host;
                    newResource.LastIssuer = ExtractIssuer(_RawData.Issuer);
                    newResource.LastExpiryUtc = _RawData.NotAfter;
                    newResource.CalculateStatus();

                    _list.Add(newResource);
                    SaveListToJson();

                    _view.UpdateStausBar();
                    _view.UpdateLastRefresh(newResource.LastCheckedUtc);
                }
                else
                {
                    //prompt user for a choice to add another site. If yes a new add site form box appears.
                    var result = MessageBox.Show($"This website: {ComputedUri.Host} is already being tracked.\nWould you like to track a different host?", "Already Tracked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (result == DialogResult.Yes) 
                    { 
                        ShowAddNewSite(); 
                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                //If there is an error a new row is still made with a tooltip in the status column for what the error is.
                newResource.HostName = userInput;
                newResource.LastErrorMessage = ex.Message;
                newResource.SetErrorStatus();

                _list.Add(newResource);

                _view.UpdateStausBar();
            }
        }



        //Updates certificate the model directly with new information if there is any.
        private async void UpdateCertificateData(CertificateModel model)
        {
            string savedHost = model.HostName;

            CertificateModel newResource = new CertificateModel();
            try
            {
                model.LastErrorMessage = null;
                model.SetFetchingStatus();

                var _RawCertData = await _certificateService.WebConnectAsync(savedHost, port);

                model.rawCertificate = _RawCertData;
                model.HostName = savedHost;
                model.LastIssuer = ExtractIssuer(_RawCertData.Issuer);
                model.LastExpiryUtc = _RawCertData.NotAfter;
                model.CalculateStatus();
                
                _view.UpdateStausBar();
                _view.UpdateLastRefresh(model.LastCheckedUtc);
            }
            catch (Exception ex)
            {
                //checks for deletion during an update request.
                //TODO: Show Notify User that a row may was deleted while updating.
                //{ MessageBox.Show("A row was deleted while Feteching certificate information and will not be added to the list.","Row Deleted",MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                model.HostName = savedHost;
                model.SetErrorStatus();
                model.LastErrorMessage = ex.Message;
            }
        }

        private async void UpdateAllData()
        {
            foreach (CertificateModel item in _list)
            {
                UpdateCertificateData(item);
            }
        }

        private void UpdateSelectedRowData(int index)
        {
            UpdateCertificateData(_list[index]);
        }

        //Removes Selected Row from the list.
        private async void RemoveSelectedItem(int index)
        {
            //if(_isFetching) 
            //{ 
            //    MessageBox.Show($"Cannot Remove at the moment Data is still being fetched from: {_list[index].HostName}", "Fetching Data", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            //    return; 
            //}
            var result = MessageBox.Show($"Would you like to stop tracking {_list[index].HostName}?", "Are You Sure?", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            _list.RemoveAt(index);
            _view.UpdateStausBar();
            SaveListToJson();
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

        private async void SaveListToJson()
        {
            await _fileService.SaveAsync(_list);
        }

        private async void LoadDataRequest()
        {
          var temp = await _fileService.GetAllAsync();

            _list.Clear();

            foreach(CertificateModel item in temp) 
            {
                item.LastErrorMessage = null;
                _list.Add(item);
                UpdateCertificateData(item);
            }
        }

        private void ShowCertificateData(int index)
        {
            if(_list[index].rawCertificate == null)
            {
                MessageBox.Show("The selected row does not have a valid certificate to view. Please select another row or refresh the list if this is a mistake.","Certificate Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            X509Certificate2UI.DisplayCertificate(_list[index].rawCertificate, _view.Handle);
        }

        private string SetErrorToolTip(int index)
        {
            if (index < 0) { return string.Empty; }

            if (_list[index].LastErrorMessage == null)
            {
                return string.Empty;
            }

            return _list[index].LastErrorMessage;

        }

        public bool TryBuildUri(string rawinput)
        {
            _rawInput = rawinput.Trim();

            if (string.IsNullOrWhiteSpace(rawinput))
            {
                return false;
            }

            if (!_rawInput.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                !_rawInput.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                _rawInput = "https://" + _rawInput;
            }
            else if (_rawInput.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                _rawInput = _rawInput.Substring(7);
                _rawInput = "https://" + _rawInput;

            }

            if (Uri.TryCreate(_rawInput, UriKind.Absolute, out Uri? validuri))
            {
                ComputedUri = validuri;
                return true;
            }
            else
            {
                return false;
            }
        }

        //replaces all quotes in the string with a space. looks for the organization column
        public string ExtractIssuer(string Issuer)
        {
            Issuer = Issuer.Replace('"', ' ');
            string[] ExtractedNames = Issuer.Split(',');

            for (int i = 0; i < ExtractedNames.Length; i++)
            {
                if (ExtractedNames[i].Contains("O="))
                {
                    return ExtractedNames[i].Split('=', StringSplitOptions.TrimEntries)[1];
                }
            }
            return string.Empty;
        }



    }
}
