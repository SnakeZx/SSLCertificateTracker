using SSLCertificateTracker.Model;
using SSLCertificateTracker.Services;
using System.ComponentModel;

namespace SSLCertificateTracker.Controller
{
    public class Controller
    {

        private readonly MainForm _view;
        private readonly AddSiteForm? _UserInputView;
        private readonly BindingList<CertificateModel> _model;
        private readonly CertificateService? _certificateService = new ();
        private readonly FileService _fileService;


        private readonly int port = 443;

        public Controller(MainForm view, CertificateModel Model, AddSiteForm userInputView, FileService fileService)
        {
            _view = view;

            _model = new BindingList<CertificateModel>();

            _UserInputView = userInputView;

            _fileService = fileService;

            _view.SetDataSource(_model);

            _view.OnAddNewSiteClick += ShowAddNewSite;

            _UserInputView.OnUserInputConfirm += GetCertificateData;

            _UserInputView.OnConfirmSave += HandleSaveRequest;
        }

        private void ShowAddNewSite()
        {
            using AddSiteForm _UserInputView = new AddSiteForm();
            if (_UserInputView.ShowDialog(_view) != DialogResult.OK)
            {
                return;
            }
        }


        private async void GetCertificateData(string userInput)
        {


            //try
            //{


            //    bool alreadytracked = false;

            //    //loops through each and returns already tracked as true if userinput matches what was a website that is already added to the sslDataGridView
            //    //for (int i = 0; i < _view.sslDataGrid.RowCount; i++)
            //    //{

            //    //    if (string.Equals(sslDataGrid.Rows[i].Cells["WebsiteColumn"].Value!.ToString(), addSiteForm.FinalUri.Host, StringComparison.OrdinalIgnoreCase))
            //    //    {
            //    //        alreadytracked = true;
            //    //        break;
            //    //    }
            //    //}

            //    if (alreadytracked)
            //    {

            //        var response = MessageBox.Show($"{addSiteForm.FinalUri.Host} is already being tracked.\n\nWould you like enter a new site?", "Already Tracked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //        if (response == DialogResult.Yes)
            //        {
            //            AddNewSiteAsync();
            //        }
            //    }
            //    else
            //    {
            //        //Returns X509Certificart2 and Stores a copy after the TcpClient and SslStream are closed.
            _model.Certificate = await _certificateService.WebConnectAsync(userInput, port);
            string certificateDataString =  

            //_view.LoadCertificate(certificateResult, addSiteForm.FinalUri.Host);
            //    }
            //}
            //catch (SocketException ex)
            //{
            //    MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private async void HandleSaveRequest()
        {
            await _fileService.SaveAsync<CertificateModel>("sites.json",_model);
        }



    }
}
