using SSLCertificateTracker.Enums;
using SSLCertificateTracker.Model;
using SSLCertificateTracker.Subclass;
using System.Diagnostics;

namespace SSLCertificateTracker
{
    public partial class MainForm : Form
    {
        //Default Fonts fro the status column and default for the row when bolding is needed.
        private readonly Font StatusColumnFont = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
        private readonly Font DeafultRowFontBold = new Font("Arial", 10F, FontStyle.Bold);
        private readonly Font DeafultRowFont = new Font("Arial", 10F, FontStyle.Regular);

        //Colors for status column
        private readonly Color StatusRedColor = Color.Red;
        private readonly Color StatusGreenColor = Color.Green;
        private readonly Color DefaultStatusFontColor = Color.Black;

        //Colors for entire row used based off the status column
        private readonly Color DefaultRowBackColor = Color.FromArgb(255, 252, 255, 255);
        private readonly Color RowRedBackColor = Color.FromArgb(245, 211, 211);
        private readonly Color RowSelectionBackColor = Color.FromArgb(218, 237, 254);

        //All events that the MainForm Raises
        public event Func<Task>? OnMainFormLoad;
        public event Func<Task>? OnMainFormClose;

        public event Func<Task>? OnAddNewSiteClick;
        public event Func<Task>? OnRefreshAllClick;
        public event Func<int, Task>? OnRefreshSelectedClick;
        public event Func<int, Task>? OnRemoveClick;
        public event Func<int, Task>? OnCellDoubleClick;
        public event Func<int, string>? ErrorMesssageTooltip;


        public MainForm()
        {
            InitializeComponent();

            //DataGrid Settings
            sslDataGrid.ReadOnly = true;
            sslDataGrid.AutoGenerateColumns = false;
            sslDataGrid.MultiSelect = false;

            remSelectedBtn.Enabled = false;
        }

        private async void addSiteBtnClick(object? sender, EventArgs e)
        {
            if (OnAddNewSiteClick != null)
            {
                try
                {
                    await OnAddNewSiteClick.Invoke();
                }
                catch (Exception ex) 
                {
                    ShowErrorToUser(ex);
                }
            }
        }


        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (OnMainFormLoad != null)
            {
                try
                {
                    UpdateStatusBarCounts();
                    await OnMainFormLoad.Invoke();
                }
                catch (Exception ex)
                {
                    ShowErrorToUser(ex);
                }
            }
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

        public void UpdateStatusBarCounts()
        {
            int count = 0;
            int ExpiredCount = 0;
            int ExpiringSoon = 0;

            foreach (DataGridViewRow row in sslDataGrid.Rows)
            {
                var cellValue = row.Cells[certStatusDesign.Index].Value;
                if (cellValue is StatusEnum status)
                {
                    if (status == StatusEnum.Expired)
                    {
                        ExpiredCount++;
                    }
                    else if (status == StatusEnum.ExpiringSoon)
                    {
                        ExpiringSoon++;
                    }

                    count++;
                }
            }

            expiredLbl.Text = $"{ExpiredCount} expired";

            expiringSoonLbl.Text = $"{ExpiringSoon} expiring soon";

            sitesTrackedLbl.Text = $"{count} sites tracked";
        }

        private async void remSelectedBtn_Click(object sender, EventArgs e)
        {
            if(OnRemoveClick != null)
            {
                try
                {
                    await OnRemoveClick.Invoke(sslDataGrid.SelectedRows[0].Index);
                }
                catch (Exception ex)
                {
                    ShowErrorToUser(ex);
                }
            }
        }

        private async void rfshSelectedBtn_Click(object sender, EventArgs e)
        {
            if (OnRefreshSelectedClick != null)
            {
                if (sslDataGrid.SelectedRows.Count > 0)
                {
                    try
                    {
                        await OnRefreshSelectedClick.Invoke(sslDataGrid.SelectedRows[0].Index);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorToUser(ex);
                    }
                }
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnMainFormClose != null)
            {
                try
                {
                    await OnMainFormClose.Invoke();
                }
                catch (Exception ex)
                {
                    ShowErrorToUser(ex);
                }
            }

        }

        internal void SetDataSource(SortableBindingList<CertificateModel> list)
        {
            DataGridViewBindingSource.DataSource = list;
        }

        private async void rfshAllBtn_Click(object sender, EventArgs e)
        {
            if (OnRefreshAllClick != null)
            {
                if (sslDataGrid.RowCount > 0)
                {
                    try
                    {
                        await OnRefreshAllClick.Invoke();
                    }
                    catch (Exception ex)
                    {
                        ShowErrorToUser(ex);
                    }
                }
            }
        }

        public void UpdateStatusBarLastRefresh(DateTime dt)
        {

            lastRefreshLbl.Text = $"Last Refresh: {dt.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        private void sslDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //checks if the cell is under the status column, makes sure the cell value is not null and is a valid enum in my StatusEnums Class.
            if (e.ColumnIndex == certStatusDesign.Index && e.Value != null && e.Value is StatusEnum status)
            {
                switch (e.Value)
                {
                    case StatusEnum.Fetching:
                        e.Value = "Fetching ....";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusGreenColor;
                        e.CellStyle.SelectionForeColor = StatusGreenColor;
                        break;
                    case StatusEnum.Okay:
                        e.Value = "\U0001F7E2 OK";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusGreenColor;
                        e.CellStyle.SelectionForeColor = StatusGreenColor;
                        break;
                    case StatusEnum.ExpiringSoon:
                        e.Value = "\U000026A0\U0000FE0F Expiring Soon";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusRedColor;
                        e.CellStyle.SelectionForeColor = StatusRedColor;
                        break;
                    case StatusEnum.Expired:
                        e.Value = "\U0001F6AB Expired";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusRedColor;
                        e.CellStyle.SelectionForeColor = StatusRedColor;
                        break;
                    case StatusEnum.Error:
                        e.Value = "\U0000274C Error";
                        e.CellStyle.Font = StatusColumnFont;
                        e.CellStyle.ForeColor = StatusRedColor;
                        e.CellStyle.SelectionForeColor = StatusRedColor;
                        break;
                }
            }

            if (e.ColumnIndex == daysLeftDesign.Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void sslDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //saves the row, and cell data into variables to made the code easier to read.
            var Row = sslDataGrid.Rows[e.RowIndex];
            var StatusCell = sslDataGrid[certStatusDesign.Index, e.RowIndex];
            var DaysLeftCell = sslDataGrid[daysLeftDesign.Index, e.RowIndex];
            var ExpiryDateCell = sslDataGrid[expiryDateCol.Index, e.RowIndex];


            //checks to make sure the value in the statuscell is an enum that is in my StatusEnums class.
            if (StatusCell.Value is StatusEnum status)
            {
                switch (StatusCell.Value)
                {
                    //Paints the row accordingly and the expiry, days left cells based on the enum in status.
                    case StatusEnum.Expired:
                    case StatusEnum.ExpiringSoon:
                        Row.DefaultCellStyle.BackColor = RowRedBackColor;
                        Row.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;

                        ExpiryDateCell.Style.ForeColor = StatusRedColor;
                        ExpiryDateCell.Style.Font = DeafultRowFontBold;
                        ExpiryDateCell.Style.SelectionForeColor = StatusRedColor;

                        DaysLeftCell.Style.ForeColor = StatusRedColor;
                        DaysLeftCell.Style.Font = DeafultRowFontBold;
                        DaysLeftCell.Style.SelectionForeColor = StatusRedColor;
                        break;
                    case StatusEnum.Error:
                        Row.DefaultCellStyle.BackColor = RowRedBackColor;
                        Row.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;
                        break;
                    case StatusEnum.Okay:
                    case StatusEnum.Fetching:
                        Row.DefaultCellStyle.BackColor = DefaultRowBackColor;
                        Row.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;

                        ExpiryDateCell.Style.ForeColor = DefaultStatusFontColor;
                        ExpiryDateCell.Style.Font = DeafultRowFont;
                        ExpiryDateCell.Style.SelectionForeColor = DefaultStatusFontColor;

                        DaysLeftCell.Style.ForeColor = DefaultStatusFontColor;
                        DaysLeftCell.Style.Font = DeafultRowFont;
                        DaysLeftCell.Style.SelectionForeColor = DefaultStatusFontColor;
                        break;

                }
            }
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
            if (e.ColumnIndex == certStatusDesign.Index)
            {
                var res = ErrorMesssageTooltip?.Invoke(e.RowIndex);

                if (res == null || res == string.Empty)
                {
                    return;
                }
                e.ToolTipText = res;
            }
        }

        private void sslDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void ShowErrorToUser(Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void UnhandledExceptionsHandler(object sender, ThreadExceptionEventArgs args)
        {
            Exception e = args.Exception;
            MessageBox.Show($"Error: {e.Message}", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
