using SSLCertificateTracker.Model;
using System.ComponentModel;

namespace SSLCertificateTracker
{
    public partial class MainForm : Form
    {
        public event Action? OnMainFormLoad;
        public event Action? OnMainFormClose;

        public event Action? OnAddNewSiteClick;
        public event Action? OnRefreshAllClick;
        public event Action<int>? OnRefreshSelectedClick;
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

        public void UpdateRowcount(int count)
        {
            sitesTrackedLbl.Text = count + " sites tracked";
        }

        private void remSelectedBtn_Click(object sender, EventArgs e)
        {
            OnRemoveClick?.Invoke(sslDataGrid.SelectedRows[0].Index);
        }

        private async void rfshSelectedBtn_Click(object sender, EventArgs e)
        {
            if (sslDataGrid.SelectedRows.Count > 0)
            {
                OnRefreshSelectedClick?.Invoke(sslDataGrid.SelectedRows[0].Index);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnMainFormClose?.Invoke();

        }

        internal void SetDataSource(SortableBindingList<CertificateModel> list)
        {
            bs.DataSource = list;
            sslDataGrid.DataSource = bs;
        }


        internal void FormatRows(int RowIndex)
        {

            var Row = sslDataGrid.Rows[RowIndex];
            var StatusCell = sslDataGrid[certStatusDesign.Index, RowIndex];
            var DaysLeftCell = sslDataGrid[daysLeftDesign.Index, RowIndex];
            var ExpiryDateCell = sslDataGrid[expiryDateCol.Index, RowIndex];

            int.TryParse(DaysLeftCell.ToString(), out int result);

            if (StatusCell.Value.ToString()!.Contains("expired", StringComparison.OrdinalIgnoreCase) 
                || StatusCell.Value.ToString()!.Contains("expiring", StringComparison.OrdinalIgnoreCase)
                )
            {
                Row.DefaultCellStyle.BackColor = Color.FromArgb(245, 211, 211);
                Row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 237, 254);

                StatusCell.Style.ForeColor = Color.Red;
                StatusCell.Style.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
                StatusCell.Style.SelectionForeColor = Color.Red;

                ExpiryDateCell.Style.ForeColor = Color.Red;
                ExpiryDateCell.Style.Font = new Font("Calibri", 12F, FontStyle.Bold);
                ExpiryDateCell.Style.SelectionForeColor = Color.Red;

                DaysLeftCell.Style.ForeColor = Color.Red;
                DaysLeftCell.Style.Font = new Font("Calibri", 12F, FontStyle.Bold);
                DaysLeftCell.Style.SelectionForeColor = Color.Red;
            }
            else if(StatusCell.Value.ToString()!.Contains("fetch", StringComparison.OrdinalIgnoreCase) 
                     || StatusCell.Value.ToString()!.Contains("ok", StringComparison.OrdinalIgnoreCase))
            {
                StatusCell.Style.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
                StatusCell.Style.ForeColor = Color.Green;
                StatusCell.Style.SelectionForeColor = Color.Green;
            }else if (StatusCell.Value.ToString()!.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                StatusCell.Style.ForeColor = Color.Red;
                StatusCell.Style.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
                StatusCell.Style.SelectionForeColor = Color.Red;

                Row.DefaultCellStyle.BackColor = Color.FromArgb(245, 211, 211);
                Row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 237, 254);
            }

        }


        internal void SetErrorToolTip(int index, string message)
        {
            var cell = sslDataGrid.Rows[index].Cells[certStatusDesign.Index];

            if (cell.Value.ToString().Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                cell.ToolTipText = message;
            }
        }

        private void rfshAllBtn_Click(object sender, EventArgs e)
        {
            if (sslDataGrid.RowCount > 0)
            {
                OnRefreshAllClick?.Invoke();
            }
        }

        public void UpdateLastRefresh(DateTime dt) 
        {
            
            lastRefreshLbl.Text = $"Last Refresh: {dt.ToString("yyyy-MM-dd HH:mm:ss")}";
        }
    }
}
