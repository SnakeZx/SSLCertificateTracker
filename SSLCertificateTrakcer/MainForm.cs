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

        //Hardcoded Port and string for the TcpClient Connection.
        public int port = 443;
        public string serverName = "www.judicatewest.com";


        public MainForm()
        {
            InitializeComponent();
        }

        private async void addSiteBtn_Click(Object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Connecting ....");

                certificateResult = await certificateService.ConnectAsync(serverName, port);

                Debug.WriteLine("Connected To: " + serverName + " - On Port: " + port);
                
                Debug.WriteLine(certificateResult.NotAfter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Error: {0}", ex);
                certificateResult = null;
                return;
            }
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

    }
}
