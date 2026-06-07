using SSLCertificateTracker.Model;
using SSLCertificateTracker.Services;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.Design.AxImporter;

namespace SSLCertificateTracker
{
    public partial class MainForm : Form
    {

        public event Action? OnAddNewSiteClick;
        public event Action? OnMainFormClick;


        public MainForm()
        {
            InitializeComponent();

            //DataGrid Settings
            sslDataGrid.ReadOnly = true;
            sslDataGrid.AutoGenerateColumns = false;
            sslDataGrid.MultiSelect = false;

            remSelectedBtn.Enabled = false;

            addSiteBtn.Click += addSiteBtnClick;



        }

        private void addSiteBtnClick(object? sender, EventArgs e)
        {
            OnAddNewSiteClick?.Invoke();
        }


        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataAsync();

            UpdateRowcount();
        }

        private void sslDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void sslDataGrid_SelectionChanged(object sender, EventArgs e)
        {

            if (sslDataGrid.SelectedRows.Count > 0)
            {
                remSelectedBtn.Enabled = true;
            }
            else
            {
                remSelectedBtn.Enabled = false;
            }

        }


        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            sslDataGrid.ClearSelection();
        }

        private void sslDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = sslDataGrid.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                sslDataGrid.ClearSelection();
            }
        }

        private void statusBar_MouseClick(object sender, MouseEventArgs e)
        {
            sslDataGrid.ClearSelection();
        }


        //public void LoadCertificate(List<DataGrid> dataGridList)
        //{

        //    //_dataGridList.Add(dataGridList);

        //    //bs!.ResetBindings(false);

        //    //UpdateRowcount();
        //}

        private void sslDataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void sslDataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void UpdateRowcount()
        {
            sitesTrackedLbl.Text = sslDataGrid.Rows.Count.ToString() + " sites tracked";
        }

        private void remSelectedBtn_Click(object sender, EventArgs e)
        {
            var mBoxResult = MessageBox.Show($"Stop tracking {sslDataGrid.SelectedRows[0].Cells["WebsiteColumn"].Value!.ToString()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mBoxResult == DialogResult.Yes)
            {
                sslDataGrid.Rows.RemoveAt(sslDataGrid.SelectedRows[0].Index);
                UpdateRowcount();
            }
        }

        private async void rfshSelectedBtn_Click(object sender, EventArgs e)
        {
            //var Website = sslDataGrid.SelectedRows[0].Cells["websiteAddressDesign"].Value.ToString();

            //certificateResult = await certificateService.WebConnectAsync(Website, port);

            ////call to LoadCertificate Method
            //UpdateCertificate(certificateResult, Website);

        }

        public void UpdateCertificate(X509Certificate2 cert, string website)
        {

            //var data = new CertificateView(cert, website);

            //var options = new JsonSerializerOptions { WriteIndented = true };

            //var json = JsonSerializer.Serialize(data, options);

            //Debug.WriteLine(json);

            //CertificateList.

            //bs.ResetBindings(false);
        }

        //private async void AddNewSiteAsync()
        //{
        //    using AddSiteForm addSiteForm = new AddSiteForm();
        //    if (addSiteForm.ShowDialog(this) != DialogResult.OK)
        //    {
        //        return;
        //    }
        //    try
        //    {


        //        bool alreadytracked = false;

        //        //loops through each and returns already tracked as true if userinput matches what was a website that is already added to the sslDataGridView
        //        for (int i = 0; i < sslDataGrid.RowCount; i++)
        //        {

        //            if (string.Equals(sslDataGrid.Rows[i].Cells["WebsiteColumn"].Value!.ToString(), addSiteForm.FinalUri.Host, StringComparison.OrdinalIgnoreCase))
        //            {
        //                alreadytracked = true;
        //                break;
        //            }
        //        }

        //        if (alreadytracked)
        //        {

        //            var response = MessageBox.Show($"{addSiteForm.FinalUri.Host} is already being tracked.\n\nWould you like enter a new site?", "Already Tracked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        //            if (response == DialogResult.Yes)
        //            {
        //                AddNewSiteAsync();
        //            }
        //        }
        //        else
        //        {
        //            //Returns X509Certificart2 and Stores a copy after the TcpClient and SslStream are closed.
        //            certificateResult = await certificateService.WebConnectAsync(addSiteForm.FinalUri.Host, port);

        //            LoadCertificate(certificateResult, addSiteForm.FinalUri.Host);
        //        }
        //    }
        //    catch (SocketException ex)
        //    {
        //        MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //Converts JSON into C# List<> object and binds that datato the list. 
        public async void InitializeDataAsync()
        {
            //string expandedFolderpath = Environment.ExpandEnvironmentVariables(FolderPath);
            //string Filepath = Environment.ExpandEnvironmentVariables(Path.Combine(FolderPath, "sites.json"));


            //JsonSerializerOptions options = new () { PropertyNameCaseInsensitive = true, IncludeFields = true };

            //if (!Directory.Exists(expandedFolderpath))
            //{
            //    Directory.CreateDirectory(expandedFolderpath);
            //    Debug.WriteLine($"Application folder not found in directory.\nNew Folder Path created for application data:\nFile Path: {expandedFolderpath}");
            //}

            ////Binding Data to the Grid before form is created.
            //if (File.Exists(Filepath))
            //{
            //    using Stream ExistingJson =  File.OpenRead(Filepath);
            //    _dataGridList = await JsonSerializer.DeserializeAsync<List<CertificateModel>>(ExistingJson, options);
            //        Debug.WriteLine($"Certificate Data Parsed From JSON.\nFile Path: {Filepath}");

            //}
            //else
            //{
            //    _dataGridList = new List<CertificateModel>();
            //    Debug.WriteLine("No File Found - New list made");
            //}
            
            //UpdateRowcount();

        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //string FilePath = Environment.ExpandEnvironmentVariables(Path.Combine(FolderPath, "sites.json"));


            //if (sslDataGrid.RowCount > 0)
            //{
            //    string updatedJson = JsonSerializer.Serialize(_dataGridList, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //    File.WriteAllText(FilePath, updatedJson);
            //    
            //}
            //else 
            //{

            //    Debug.WriteLine("No rows in datagrid. No json file will be created.");
            //}
        }

        internal void SetDataSource(BindingList<CertificateModel> list)
        {
            sslDataGrid.DataSource = list;
        }
    }
}
