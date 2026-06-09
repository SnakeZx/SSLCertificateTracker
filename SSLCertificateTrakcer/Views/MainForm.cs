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

        public event Action<List<CertificateModel>>? OnLoadPopulateGridData;


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

        }

        //Converts JSON into C# List<> object and binds that datato the list. 
        public async void InitializeDataAsync()
        { 

        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        internal void SetDataSource(BindingList<CertificateModel> list)
        {
            sslDataGrid.DataSource = list;
        }
    }
}
