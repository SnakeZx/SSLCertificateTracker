using SSLCertificateTracker.Enums;
using SSLCertificateTracker.Model;
using SSLCertificateTracker.Subclass;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

namespace SSLCertificateTracker
{
    public partial class MainForm : Form
    {

        private readonly Font StatusColumnFont = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
        private readonly Font DeafultRowFontBold = new Font("Arial", 10F, FontStyle.Bold);
        private readonly Font DeafultRowFont = new Font("Arial", 10F, FontStyle.Regular);

        private readonly Color StatusRedColor = Color.Red;
        private readonly Color StatusGreenColor = Color.Green;
        private readonly Color RowRedBackColor = Color.FromArgb(245, 211, 211);
        private readonly Color RowSelectionBackColor = Color.FromArgb(218, 237, 254);

        public event Action? OnMainFormLoad;
        public event Action? OnMainFormClose;

        public event Action? OnAddNewSiteClick;
        public event Action? OnRefreshAllClick;
        public event Action<int>? OnRefreshSelectedClick;
        public event Action<int>? OnRemoveClick;
        public event Action<int>? OnCellDoubleClick;
        public event Func<int, string>? ErrorMesssageTooltip;

        private BindingSource bs = new();

        private string _errorToolTip = string.Empty;


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
                //OnRefreshSelectedClick?.Invoke(sslDataGrid.SelectedRows[0].Index);
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

        private void sslDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if(e.ColumnIndex == certStatusDesign.Index && e.Value != null && e.Value is StatusEnums status)
            {
                switch (e.Value)
                {
                    case StatusEnums.Fetching:
                        e.Value = "Fetching ....";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusGreenColor;
                        e.CellStyle.SelectionForeColor = StatusGreenColor;
                        break;
                    case StatusEnums.Okay:
                        e.Value = "\U0001F7E2 OK";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusGreenColor;
                        e.CellStyle.SelectionForeColor = StatusGreenColor;
                        break;
                    case StatusEnums.ExpiringSoon:
                        e.Value = "\U000026A0\U0000FE0F Expiring Soon";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusRedColor;
                        e.CellStyle.SelectionForeColor = StatusRedColor;
                        break;
                    case StatusEnums.Expired:
                        e.Value = "\U0001F6AB Expired";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusRedColor;
                        e.CellStyle.SelectionForeColor = StatusRedColor;
                        break;
                }
            }


            //if (e.ColumnIndex == certStatusDesign.Index && e.Value.ToString()!.Contains("fetch", StringComparison.OrdinalIgnoreCase)
            //         || e.Value.ToString()!.Contains("ok", StringComparison.OrdinalIgnoreCase))
            //{
            //    e.CellStyle.Font = StatusColumnFont;
            //    e.CellStyle.ForeColor = StatusGreenColor;
            //    e.CellStyle.SelectionForeColor = StatusGreenColor;
            //}
            //else if (e.ColumnIndex == certStatusDesign.Index && e.Value.ToString()!.Contains("expired", StringComparison.OrdinalIgnoreCase)
            //    || e.Value.ToString()!.Contains("expiring", StringComparison.OrdinalIgnoreCase)
            //    )
            //{
            //    e.CellStyle.Font = StatusColumnFont;
            //    e.CellStyle.ForeColor = StatusRedColor;
            //    e.CellStyle.SelectionForeColor = StatusRedColor;
            //}
            //else if (e.ColumnIndex == certStatusDesign.Index && e.Value.ToString()!.Contains("error", StringComparison.OrdinalIgnoreCase))
            //{
            //    e.CellStyle.ForeColor = StatusRedColor;
            //    e.CellStyle.Font = StatusColumnFont;
            //    e.CellStyle.SelectionForeColor = StatusRedColor;
            //}
            //else if (e.ColumnIndex == daysLeftDesign.Index)
            //{
            //    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
        }

        private void sslDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var Row = sslDataGrid.Rows[e.RowIndex];
            var StatusCell = sslDataGrid[certStatusDesign.Index, e.RowIndex];
            var DaysLeftCell = sslDataGrid[daysLeftDesign.Index, e.RowIndex];
            var ExpiryDateCell = sslDataGrid[expiryDateCol.Index, e.RowIndex];

            if(StatusCell.Value is StatusEnums status)
            {
                switch (StatusCell.Value)
                {
                    case StatusEnums.Expired:
                    case StatusEnums.ExpiringSoon:
                        Row.DefaultCellStyle.BackColor = RowRedBackColor;
                        Row.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;

                        ExpiryDateCell.Style.ForeColor = StatusRedColor;
                        ExpiryDateCell.Style.Font = DeafultRowFontBold;
                        ExpiryDateCell.Style.SelectionForeColor = StatusRedColor;

                        DaysLeftCell.Style.ForeColor = StatusRedColor;
                        DaysLeftCell.Style.Font = DeafultRowFontBold;
                        DaysLeftCell.Style.SelectionForeColor = StatusRedColor;
                        break;
                    case StatusEnums.Error:
                        Row.DefaultCellStyle.BackColor = RowRedBackColor;
                        Row.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;
                        break;
                        
                }
            }


            //if (StatusCell.Value.ToString()!.Contains("expired", StringComparison.OrdinalIgnoreCase)
            //    || StatusCell.Value.ToString()!.Contains("expiring", StringComparison.OrdinalIgnoreCase)
            //    )
            //{
            //    Row.DefaultCellStyle.BackColor = RowRedBackColor;
            //    Row.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;

            //    ExpiryDateCell.Style.ForeColor = StatusRedColor;
            //    ExpiryDateCell.Style.Font = DeafultRowFontBold;
            //    ExpiryDateCell.Style.SelectionForeColor = StatusRedColor;

            //    DaysLeftCell.Style.ForeColor = StatusRedColor;
            //    DaysLeftCell.Style.Font = DeafultRowFontBold;
            //    DaysLeftCell.Style.SelectionForeColor = StatusRedColor;
            //}
            //else if (StatusCell.Value.ToString()!.Contains("error", StringComparison.OrdinalIgnoreCase))
            //{
            //    Row.DefaultCellStyle.BackColor = RowRedBackColor;
            //    Row.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;

            //}
        }

        private void sslDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sslDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == WebsiteColumn.Index)
            {
                OnCellDoubleClick?.Invoke(e.RowIndex);
            }
        }

        private void sslDataGrid_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if(e.ColumnIndex == certStatusDesign.Index)
            {
                var res = ErrorMesssageTooltip?.Invoke(e.RowIndex);
                if(res == null || res == string.Empty) { return; }
                e.ToolTipText = ErrorMesssageTooltip?.Invoke(e.RowIndex);
            }
        }

        private void sslDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
}
