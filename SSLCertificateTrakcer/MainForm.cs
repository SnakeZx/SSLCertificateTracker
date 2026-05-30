using System.Diagnostics;
using System.Net.Sockets;

namespace SSLCertificateTrakcer
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private async void addSiteBtn_Click(Object sender, EventArgs e)
        {
            AddSiteForm addStireForm = new AddSiteForm();

            addStireForm.ShowDialog();
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
