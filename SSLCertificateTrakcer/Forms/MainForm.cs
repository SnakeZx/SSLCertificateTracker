using SSLCertificateTrakcer.Model;
using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace SSLCertificateTrakcer
{
    public partial class MainForm : Form
    {


        //Creates a new object for my created class that can be called from here when actions are preformed.
        private CertificateService certificateService = new CertificateService();
        private X509Certificate2 certificateResult;


        //Creates a new object for my created class that can be called from here when actions are preformed.
        List<CertificateView> CertificateList;
        BindingSource bs;

        //Hardcoded Port and string for the TcpClient Connection.
        public int port = 443;
        public string serverName = "judicateWest.com";

        public MainForm()
        {
            InitializeComponent();

            //Binding Data to the Grid before form is created.
            CertificateList = new List<CertificateView>();
            bs = new BindingSource();

            bs.DataSource = CertificateList;
            sslDataGrid.DataSource = bs;

            //DataGrid Settings
            sslDataGrid.ReadOnly = true;
            sslDataGrid.AutoGenerateColumns = false;
            sslDataGrid.MultiSelect = false;

            remSelectedBtn.Enabled = false;
        }

        private async void addSiteBtn_Click(Object sender, EventArgs e)
        {
            Debug.WriteLine($"addSiteBtn_Click entered at {DateTime.Now:HH:mm:ss.fff}");
            using AddSiteForm addSiteForm = new AddSiteForm();
            if (addSiteForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            try
            {

                Debug.WriteLine("Connecting ....");

                Debug.WriteLine(addSiteForm.finalUri.Host);

                certificateResult = await certificateService.WebConnectAsync(addSiteForm.finalUri.Host, port);

                Debug.WriteLine("Connected To: " + addSiteForm.UserInput + " - On Port: " + port);

                LoadCertificate(certificateResult,addSiteForm.finalUri.Host);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine("Exception: {0}", ex);
            }



            addSiteForm.ShowDialog();
        }

        private void statusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            CertificateList.Add(data);

            bs.ResetBindings(false);
        }
    }
}
