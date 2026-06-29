namespace SSLCertificateTracker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            AddSiteButton = new Button();
            sslDataGrid = new DataGridView();
            WebsiteColumn = new DataGridViewTextBoxColumn();
            certIssuerDesign = new DataGridViewTextBoxColumn();
            expiryDateCol = new DataGridViewTextBoxColumn();
            daysLeftDesign = new DataGridViewTextBoxColumn();
            certStatusDesign = new DataGridViewTextBoxColumn();
            DataGridViewBindingSource = new BindingSource(components);
            statusBar = new StatusStrip();
            sitesTrackedLbl = new ToolStripStatusLabel();
            lblSep1 = new ToolStripStatusLabel();
            expiringSoonLbl = new ToolStripStatusLabel();
            lblSep2 = new ToolStripStatusLabel();
            expiredLbl = new ToolStripStatusLabel();
            lblSep3 = new ToolStripStatusLabel();
            lastRefreshLbl = new ToolStripStatusLabel();
            RefreshAllButton = new Button();
            RefreshSelectedButton = new Button();
            RemoveSelectedButton = new Button();
            RightClickMenu = new ContextMenuStrip(components);
            RefreshSelectedMenuItem = new ToolStripMenuItem();
            RemoveSelectedMenuItem = new ToolStripMenuItem();
            ShowCertificateMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)sslDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridViewBindingSource).BeginInit();
            statusBar.SuspendLayout();
            RightClickMenu.SuspendLayout();
            SuspendLayout();
            // 
            // AddSiteButton
            // 
            AddSiteButton.AutoSize = true;
            AddSiteButton.BackColor = Color.FromArgb(35, 122, 254);
            AddSiteButton.FlatAppearance.BorderSize = 0;
            AddSiteButton.FlatStyle = FlatStyle.Flat;
            AddSiteButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddSiteButton.ForeColor = Color.White;
            AddSiteButton.Location = new Point(12, 12);
            AddSiteButton.Name = "AddSiteButton";
            AddSiteButton.Size = new Size(115, 39);
            AddSiteButton.TabIndex = 0;
            AddSiteButton.Text = "+ Add Site";
            AddSiteButton.UseVisualStyleBackColor = false;
            AddSiteButton.Click += addSiteBtnClick;
            // 
            // sslDataGrid
            // 
            sslDataGrid.AllowUserToAddRows = false;
            sslDataGrid.AllowUserToDeleteRows = false;
            sslDataGrid.AllowUserToResizeColumns = false;
            sslDataGrid.AllowUserToResizeRows = false;
            sslDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sslDataGrid.AutoGenerateColumns = false;
            sslDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sslDataGrid.BackgroundColor = Color.White;
            sslDataGrid.BorderStyle = BorderStyle.None;
            sslDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(201, 201, 201);
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(201, 201, 201);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            sslDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            sslDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sslDataGrid.Columns.AddRange(new DataGridViewColumn[] { WebsiteColumn, certIssuerDesign, expiryDateCol, daysLeftDesign, certStatusDesign });
            sslDataGrid.DataSource = DataGridViewBindingSource;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Arial", 10F);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            sslDataGrid.DefaultCellStyle = dataGridViewCellStyle7;
            sslDataGrid.EnableHeadersVisualStyles = false;
            sslDataGrid.GridColor = Color.DarkGray;
            sslDataGrid.Location = new Point(12, 57);
            sslDataGrid.Name = "sslDataGrid";
            sslDataGrid.ReadOnly = true;
            sslDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Arial", 10F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(218, 237, 254);
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            sslDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            sslDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sslDataGrid.ShowEditingIcon = false;
            sslDataGrid.Size = new Size(1110, 576);
            sslDataGrid.TabIndex = 1;
            sslDataGrid.CellDoubleClick += SslDataGrid_CellDoubleClick;
            sslDataGrid.CellFormatting += SslDataGrid_CellFormatting;
            sslDataGrid.CellToolTipTextNeeded += SslDataGrid_CellToolTipTextNeeded;
            sslDataGrid.DataError += SslDataGrid_DataError;
            sslDataGrid.RowPrePaint += SslDataGrid_RowPrePaint;
            sslDataGrid.SelectionChanged += SslDataGrid_SelectionChanged;
            sslDataGrid.MouseClick += SslDataGrid_MouseClick;
            sslDataGrid.MouseDown += SslDataGrid_MouseDown;
            // 
            // WebsiteColumn
            // 
            WebsiteColumn.DataPropertyName = "HostName";
            dataGridViewCellStyle2.Font = new Font("Arial", 10F);
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            WebsiteColumn.DefaultCellStyle = dataGridViewCellStyle2;
            WebsiteColumn.FillWeight = 32F;
            WebsiteColumn.HeaderText = "Website";
            WebsiteColumn.Name = "WebsiteColumn";
            WebsiteColumn.ReadOnly = true;
            WebsiteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // certIssuerDesign
            // 
            certIssuerDesign.DataPropertyName = "LastIssuer";
            dataGridViewCellStyle3.Font = new Font("Arial", 10F);
            certIssuerDesign.DefaultCellStyle = dataGridViewCellStyle3;
            certIssuerDesign.FillWeight = 32F;
            certIssuerDesign.HeaderText = "Issuer";
            certIssuerDesign.Name = "certIssuerDesign";
            certIssuerDesign.ReadOnly = true;
            certIssuerDesign.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // expiryDateCol
            // 
            expiryDateCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            expiryDateCol.DataPropertyName = "LastExpiryUtc";
            dataGridViewCellStyle4.Font = new Font("Arial", 10F);
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            dataGridViewCellStyle4.NullValue = null;
            expiryDateCol.DefaultCellStyle = dataGridViewCellStyle4;
            expiryDateCol.FillWeight = 11F;
            expiryDateCol.HeaderText = "Expiry Date";
            expiryDateCol.Name = "expiryDateCol";
            expiryDateCol.ReadOnly = true;
            expiryDateCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // daysLeftDesign
            // 
            daysLeftDesign.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            daysLeftDesign.DataPropertyName = "daysLeft";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Arial", 10F);
            daysLeftDesign.DefaultCellStyle = dataGridViewCellStyle5;
            daysLeftDesign.FillWeight = 20.58242F;
            daysLeftDesign.HeaderText = "Days Left";
            daysLeftDesign.MinimumWidth = 63;
            daysLeftDesign.Name = "daysLeftDesign";
            daysLeftDesign.ReadOnly = true;
            daysLeftDesign.SortMode = DataGridViewColumnSortMode.NotSortable;
            daysLeftDesign.Width = 75;
            // 
            // certStatusDesign
            // 
            certStatusDesign.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            certStatusDesign.DataPropertyName = "Status";
            dataGridViewCellStyle6.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            certStatusDesign.DefaultCellStyle = dataGridViewCellStyle6;
            certStatusDesign.FillWeight = 25F;
            certStatusDesign.HeaderText = "Status";
            certStatusDesign.Name = "certStatusDesign";
            certStatusDesign.ReadOnly = true;
            certStatusDesign.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // DataGridViewBindingSource
            // 
            DataGridViewBindingSource.DataSource = typeof(Model.CertificateModel);
            // 
            // statusBar
            // 
            statusBar.AllowMerge = false;
            statusBar.BackColor = Color.FromArgb(35, 122, 254);
            statusBar.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusBar.Items.AddRange(new ToolStripItem[] { sitesTrackedLbl, lblSep1, expiringSoonLbl, lblSep2, expiredLbl, lblSep3, lastRefreshLbl });
            statusBar.Location = new Point(0, 639);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(1134, 22);
            statusBar.SizingGrip = false;
            statusBar.TabIndex = 1;
            statusBar.MouseClick += StatusBar_MouseClick;
            // 
            // sitesTrackedLbl
            // 
            sitesTrackedLbl.ForeColor = Color.White;
            sitesTrackedLbl.Name = "sitesTrackedLbl";
            sitesTrackedLbl.Size = new Size(77, 17);
            sitesTrackedLbl.Text = "sites tracked";
            // 
            // lblSep1
            // 
            lblSep1.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSep1.ForeColor = Color.White;
            lblSep1.Name = "lblSep1";
            lblSep1.Size = new Size(13, 17);
            lblSep1.Text = "|";
            // 
            // expiringSoonLbl
            // 
            expiringSoonLbl.ForeColor = Color.White;
            expiringSoonLbl.Name = "expiringSoonLbl";
            expiringSoonLbl.Size = new Size(81, 17);
            expiringSoonLbl.Text = "expiring soon";
            // 
            // lblSep2
            // 
            lblSep2.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSep2.ForeColor = Color.White;
            lblSep2.Name = "lblSep2";
            lblSep2.Size = new Size(13, 17);
            lblSep2.Text = "|";
            // 
            // expiredLbl
            // 
            expiredLbl.ForeColor = Color.White;
            expiredLbl.Name = "expiredLbl";
            expiredLbl.Size = new Size(48, 17);
            expiredLbl.Text = "expired";
            // 
            // lblSep3
            // 
            lblSep3.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSep3.ForeColor = Color.White;
            lblSep3.Name = "lblSep3";
            lblSep3.Size = new Size(13, 17);
            lblSep3.Text = "|";
            // 
            // lastRefreshLbl
            // 
            lastRefreshLbl.ForeColor = Color.White;
            lastRefreshLbl.Name = "lastRefreshLbl";
            lastRefreshLbl.Size = new Size(80, 17);
            lastRefreshLbl.Text = "Last Refresh: ";
            // 
            // RefreshAllButton
            // 
            RefreshAllButton.AutoSize = true;
            RefreshAllButton.BackColor = Color.White;
            RefreshAllButton.FlatAppearance.BorderSize = 0;
            RefreshAllButton.FlatStyle = FlatStyle.Flat;
            RefreshAllButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshAllButton.ForeColor = Color.Black;
            RefreshAllButton.Image = (Image)resources.GetObject("RefreshAllButton.Image");
            RefreshAllButton.Location = new Point(133, 12);
            RefreshAllButton.Name = "RefreshAllButton";
            RefreshAllButton.Size = new Size(115, 39);
            RefreshAllButton.TabIndex = 2;
            RefreshAllButton.Text = "Refresh All";
            RefreshAllButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            RefreshAllButton.UseVisualStyleBackColor = false;
            RefreshAllButton.Click += RefreshAllBtton_Click;
            // 
            // RefreshSelectedButton
            // 
            RefreshSelectedButton.AutoSize = true;
            RefreshSelectedButton.BackColor = Color.White;
            RefreshSelectedButton.FlatAppearance.BorderSize = 0;
            RefreshSelectedButton.FlatStyle = FlatStyle.Flat;
            RefreshSelectedButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshSelectedButton.ForeColor = Color.Black;
            RefreshSelectedButton.Image = (Image)resources.GetObject("RefreshSelectedButton.Image");
            RefreshSelectedButton.Location = new Point(254, 12);
            RefreshSelectedButton.Name = "RefreshSelectedButton";
            RefreshSelectedButton.Size = new Size(152, 39);
            RefreshSelectedButton.TabIndex = 3;
            RefreshSelectedButton.Text = "Refresh Selected";
            RefreshSelectedButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            RefreshSelectedButton.UseVisualStyleBackColor = false;
            RefreshSelectedButton.Click += RefreshSelectedButton_Click;
            // 
            // RemoveSelectedButton
            // 
            RemoveSelectedButton.AutoSize = true;
            RemoveSelectedButton.BackColor = Color.White;
            RemoveSelectedButton.FlatAppearance.BorderSize = 0;
            RemoveSelectedButton.FlatStyle = FlatStyle.Flat;
            RemoveSelectedButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RemoveSelectedButton.ForeColor = Color.Black;
            RemoveSelectedButton.Image = (Image)resources.GetObject("RemoveSelectedButton.Image");
            RemoveSelectedButton.Location = new Point(412, 12);
            RemoveSelectedButton.Name = "RemoveSelectedButton";
            RemoveSelectedButton.Size = new Size(154, 39);
            RemoveSelectedButton.TabIndex = 4;
            RemoveSelectedButton.Text = "Remove Selected";
            RemoveSelectedButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            RemoveSelectedButton.UseVisualStyleBackColor = false;
            RemoveSelectedButton.Click += RemoveSelectedButton_Click;
            // 
            // RightClickMenu
            // 
            RightClickMenu.BackgroundImageLayout = ImageLayout.None;
            RightClickMenu.Items.AddRange(new ToolStripItem[] { RefreshSelectedMenuItem, RemoveSelectedMenuItem, ShowCertificateMenuItem });
            RightClickMenu.Name = "contextMenuStrip1";
            RightClickMenu.ShowImageMargin = false;
            RightClickMenu.Size = new Size(140, 70);
            // 
            // RefreshSelectedMenuItem
            // 
            RefreshSelectedMenuItem.CheckOnClick = true;
            RefreshSelectedMenuItem.Name = "RefreshSelectedMenuItem";
            RefreshSelectedMenuItem.Size = new Size(139, 22);
            RefreshSelectedMenuItem.Text = "Refresh Selected";
            RefreshSelectedMenuItem.Click += RefreshSelectedButton_Click;
            // 
            // RemoveSelectedMenuItem
            // 
            RemoveSelectedMenuItem.CheckOnClick = true;
            RemoveSelectedMenuItem.Name = "RemoveSelectedMenuItem";
            RemoveSelectedMenuItem.Size = new Size(139, 22);
            RemoveSelectedMenuItem.Text = "Remove Selected";
            RemoveSelectedMenuItem.Click += RemoveSelectedButton_Click;
            // 
            // ShowCertificateMenuItem
            // 
            ShowCertificateMenuItem.Name = "ShowCertificateMenuItem";
            ShowCertificateMenuItem.Size = new Size(139, 22);
            ShowCertificateMenuItem.Text = "Show Certificate";
            ShowCertificateMenuItem.Click += ShowCertificateMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(213, 213, 213);
            ClientSize = new Size(1134, 661);
            Controls.Add(RemoveSelectedButton);
            Controls.Add(RefreshSelectedButton);
            Controls.Add(RefreshAllButton);
            Controls.Add(statusBar);
            Controls.Add(sslDataGrid);
            Controls.Add(AddSiteButton);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 700);
            Name = "MainForm";
            Text = "SSL Certificate Tracker";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            MouseClick += MainForm_MouseClick;
            ((System.ComponentModel.ISupportInitialize)sslDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridViewBindingSource).EndInit();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            RightClickMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddSiteButton;
        private DataGridView sslDataGrid;
        private StatusStrip statusBar;
        private ToolStripStatusLabel sitesTrackedLbl;
        private ToolStripStatusLabel expiringSoonLbl;
        private ToolStripStatusLabel expiredLbl;
        private ToolStripStatusLabel lastRefreshLbl;
        private Button RefreshAllButton;
        private Button RefreshSelectedButton;
        private Button RemoveSelectedButton;
        private ToolStripStatusLabel lblSep1;
        private ToolStripStatusLabel lblSep2;
        private ToolStripStatusLabel lblSep3;
        private BindingSource DataGridViewBindingSource;
        private DataGridViewTextBoxColumn WebsiteColumn;
        private DataGridViewTextBoxColumn certIssuerDesign;
        private DataGridViewTextBoxColumn expiryDateCol;
        private DataGridViewTextBoxColumn daysLeftDesign;
        private DataGridViewTextBoxColumn certStatusDesign;
        private ContextMenuStrip RightClickMenu;
        private ToolStripMenuItem RefreshSelectedMenuItem;
        private ToolStripMenuItem RemoveSelectedMenuItem;
        private ToolStripMenuItem ShowCertificateMenuItem;
    }
}
