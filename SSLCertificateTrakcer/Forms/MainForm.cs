using SSLCertificateTrakcer.Model;
using System.Data;
using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.Design.AxImporter;

namespace SSLCertificateTrakcer
{
    public partial class MainForm : Form
    {
        string FolderPath = @"%APPDATA%\SSLCertTracker";
        string FilePath = @"%APPDATA%\SSLCertTracker\sites.json";


        //Creates a new object for my created class that can be called from here when actions are preformed.
        private CertificateService certificateService = new CertificateService();
        private X509Certificate2? certificateResult;


        //Creates a new object for my created class that can be called from here when actions are preformed.
        List<CertificateView> CertificateList;
        BindingSource bs;

        //Hardcoded Port and string for the TcpClient Connection.
        public int port = 443;

        public MainForm()
        {
            InitializeComponent();

            string expandedFilepath = Environment.ExpandEnvironmentVariables(FilePath);
            string expandedFolderpath = Environment.ExpandEnvironmentVariables(FolderPath);

            if (!Directory.Exists(expandedFolderpath))
            {
                Directory.CreateDirectory(expandedFolderpath);
            }

            //Binding Data to the Grid before form is created.

            if (File.Exists(expandedFilepath))
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string ExistingJson = File.ReadAllText(expandedFilepath);
                CertificateList = JsonSerializer.Deserialize<List<CertificateView>>(ExistingJson)!;
                Debug.WriteLine($"Certificate Data Parsed From JSON.\nFile Path: {expandedFilepath}");

            }
            else
            {
                CertificateList = new List<CertificateView>();
                Debug.WriteLine("No File Found - New list made");
            }


            bs = new BindingSource();

            bs.DataSource = CertificateList;
            sslDataGrid.DataSource = bs;

            //DataGrid Settings
            sslDataGrid.ReadOnly = true;
            sslDataGrid.AutoGenerateColumns = false;
            sslDataGrid.MultiSelect = false;

            remSelectedBtn.Enabled = false;
        }

        private void addSiteBtn_Click(object sender, EventArgs e)
        {
            AddNewSiteAsync();
        }


        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateRowcount();
            
            string expandedpath = Environment.ExpandEnvironmentVariables(FilePath);
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


        public void LoadCertificate(X509Certificate2 cert, string website)
        {

            var data = new CertificateView(cert, website);

            var options = new JsonSerializerOptions { WriteIndented = true };

            CertificateList.Add(data);

            var json = JsonSerializer.Serialize(data, options);

            Debug.WriteLine(json);

            bs.ResetBindings(false);

            UpdateRowcount();
        }

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
            var mBoxResult = MessageBox.Show($"Stop tracking {sslDataGrid.SelectedRows[0].Cells["websiteAddressDesign"].Value!.ToString()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private async void AddNewSiteAsync()
        {
            using AddSiteForm addSiteForm = new AddSiteForm();
            if (addSiteForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            try
            {

                //Returns X509Certificart2 and Stores a copy after the TcpClient and SslStream are closed.
                certificateResult = await certificateService.WebConnectAsync(addSiteForm.FinalUri.Host, port);

                bool alreadytracked = false;

                //loops through each and returns already tracked as true if userinput matches what was a website that is already added to the sslDataGridView
                for (int i = 0; i < sslDataGrid.RowCount; i++)
                {

                    if (string.Equals(sslDataGrid.Rows[i].Cells["websiteAddressDesign"].Value!.ToString(), addSiteForm.FinalUri.Host, StringComparison.OrdinalIgnoreCase))
                    {
                        alreadytracked = true;
                        break;
                    }
                }

                if (alreadytracked)
                {

                    var response = MessageBox.Show($"{addSiteForm.FinalUri.Host} is already being tracked.\n\nWould you like enter a new site?", "Already Tracked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (response == DialogResult.Yes)
                    {
                        AddNewSiteAsync();
                    }
                }
                else
                {
                    LoadCertificate(certificateResult, addSiteForm.FinalUri.Host);
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string expandedpath = Environment.ExpandEnvironmentVariables(FilePath);
            if (sslDataGrid.RowCount > 0)
            {
                string updatedJson = JsonSerializer.Serialize(CertificateList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(expandedpath, updatedJson);
                Debug.WriteLine($"JSON File Created at: {expandedpath}");
            }
            else
            {
                Debug.WriteLine($"NO ROWS FOUND! FILE NOT CREATED!");
            }
        }
    }
}
