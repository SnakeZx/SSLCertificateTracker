using SSLCertificateTracker.Model;
using System.ComponentModel;

namespace SSLCertificateTracker
{
    public partial class MainForm : Form
    {
        public event Action? OnMainFormLoad;
        public event Action? OnMainFormClose;

        public event Action? OnAddNewSiteClick;
        public event Action? OnMainFormClick;


        public event Action<int>? OnRemoveClick;

        private BindingSource bs = new();


        public MainForm()
        {
            InitializeComponent();

            //DataGrid Settings
            sslDataGrid.ReadOnly = true;
            sslDataGrid.AutoGenerateColumns = false;
            sslDataGrid.MultiSelect = false;

            remSelectedBtn.Enabled = false;
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
            OnMainFormLoad?.Invoke();

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
            OnRemoveClick?.Invoke(sslDataGrid.SelectedRows[0].Index);
        }

        private async void rfshSelectedBtn_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnMainFormClose?.Invoke();

        }

        internal void SetDataSource(BindingList<CertificateModel> list)
        {
            bs.DataSource = list;
            sslDataGrid.DataSource = bs;
        }

        private void sslDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == certStatusDesign.Index && e.Value.ToString().Contains("ok", StringComparison.OrdinalIgnoreCase) || e.Value.ToString().Contains("fetch", StringComparison.OrdinalIgnoreCase)) 
            {
                e.CellStyle.ForeColor = Color.Green;
            }
            else if(e.ColumnIndex == certStatusDesign.Index)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold);
            }
        }
    }
}
