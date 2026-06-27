using SSLCertificateTracker.Enums;
using SSLCertificateTracker.Model;
using SSLCertificateTracker.Subclass;
using System.Diagnostics;

namespace SSLCertificateTracker
{
    public partial class MainForm : Form
    {
        #region Readony Properties
        //Default Fonts for the status column and default for the row when bolding is needed.
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
        #endregion

        private bool _isFetching;

        #region Public Events
        //All events that the MainForm Raises and returns the task.
        public event Func<Task>? OnMainFormLoad;
        public event Func<Task>? OnMainFormClose;

        public event Func<Task>? OnAddNewSiteClick;
        public event Func<Task>? OnRefreshAllClick;
        public event Func<int, Task>? OnRefreshSelectedClick;
        public event Func<int, Task>? OnRemoveClick;
        public event Func<int, Task>? ViewCertificateData;
        public event Func<int, string>? ErrorMesssageTooltip;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            //DataGrid Settings
            sslDataGrid.ReadOnly = true;
            sslDataGrid.AutoGenerateColumns = false;
            sslDataGrid.MultiSelect = false;

            RemoveSelectedButton.Enabled = false;
        }

        public void IsFetchingFlag(bool isFetching)
        {
            _isFetching = isFetching;
            sslDataGrid.ClearSelection();
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
        public void UpdateStatusBarLastRefresh(DateTime dt)
        {

            lastRefreshLbl.Text = $"Last Refresh: {dt.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        private async void addSiteBtnClick(object sender, EventArgs e)
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


        //enables/disables the button and context menu item for refresh and remove actions
        private void SslDataGrid_SelectionChanged(object sender, EventArgs e)
        {

            if (sslDataGrid.SelectedRows.Count > 0)
            {
                RemoveSelectedButton.Enabled = true;
                RemoveSelectedMenuItem.Enabled = true;
                RefreshSelectedButton.Enabled = true;
                RefreshSelectedMenuItem.Enabled = true;
                ShowCertificateMenuItem.Enabled = true;
            }
            else
            {
                RemoveSelectedButton.Enabled = false;
                RemoveSelectedMenuItem.Enabled = false;
                RefreshSelectedButton.Enabled = false;
                RefreshSelectedMenuItem.Enabled = false;
                ShowCertificateMenuItem.Enabled = false;
                RightClickMenu.Hide();
            }

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            sslDataGrid.ClearSelection(); //Deselects a row by clicking any where on the form.
        }

        //adds functionality to deselect a row by clicking on empty space on the datagridview
        private void SslDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = sslDataGrid.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                sslDataGrid.ClearSelection();
            }
        }

        private void StatusBar_MouseClick(object sender, MouseEventArgs e)
        {
            sslDataGrid.ClearSelection(); //Deselects a row by clicking status bar at the bottom
        }


        private async void RemoveSelectedButton_Click(object sender, EventArgs e)
        {
            if (OnRemoveClick != null)
            {
                if (_isFetching)
                {
                    ShowFetchingDataDialog();
                    return;
                }
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

        private async void RefreshSelectedButton_Click(object sender, EventArgs e)
        {
            if (OnRefreshSelectedClick != null)
            {
                if (_isFetching)
                {
                    ShowFetchingDataDialog();
                    return;
                }
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

        private async void RefreshAllBtton_Click(object sender, EventArgs e)
        {
            if (OnRefreshAllClick != null)
            {
                if (sslDataGrid.RowCount > 0)
                {
                    if (_isFetching)
                    {
                        ShowFetchingDataDialog();
                        return;
                    }
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


        private void SslDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void SslDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //saves the row, and cell data into variables to made the code easier to read.
            var Row = sslDataGrid.Rows[e.RowIndex];
            var StatusCell = sslDataGrid[certStatusDesign.Index, e.RowIndex];
            var DaysLeftCell = sslDataGrid[daysLeftDesign.Index, e.RowIndex];
            var ExpiryDateCell = sslDataGrid[expiryDateCol.Index, e.RowIndex];


            //checks to make sure the value in the statuscell is an enum that is in my StatusEnums class.
            if (StatusCell.Value is StatusEnum)
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

        private void SslDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isFetching)
            {
                ShowFetchingDataDialog();
                return;
            }

            if (sslDataGrid.SelectedRows.Count > 0)
            {
                ViewCertificateData?.Invoke(e.RowIndex);
            }
        }

        private void SslDataGrid_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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
        private void ShowCertificateMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFetching)
            {
                ShowFetchingDataDialog();
                return;
            }
            if (sslDataGrid.SelectedRows.Count > 0)
            {
                ViewCertificateData?.Invoke(sslDataGrid.SelectedRows[0].Index);
            }
        }
        private void SslDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:

                    var hit = sslDataGrid.HitTest(e.X, e.Y);

                    if (hit.Type == DataGridViewHitTestType.ColumnHeader)
                    {
                        break;
                    }
                    if (hit.Type == DataGridViewHitTestType.None)
                    {
                        sslDataGrid.ClearSelection();
                        break;
                    }

                    sslDataGrid.Rows[hit.RowIndex].Selected = true;
                    RightClickMenu.Show(sslDataGrid, new Point(e.X, e.Y));
                    break;
            }
        }

        private void SslDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        static private void ShowFetchingDataDialog()
        {
            MessageBox.Show($"Cannot perform this action while a refresh is in progress. Please wait for items to finish refreshing and try again.", "Refresh In Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static private void ShowErrorToUser(Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "ERROR: UI Thread", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void BackgroundThreadsUnhandledExceptionsHandler(object sender, ThreadExceptionEventArgs args)
        {
            MessageBox.Show($"ERROR MESSAGE: {args.Exception.Message}\n\nStack Trace:\n{args.Exception.StackTrace}", "ERROR: Background Thread", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
