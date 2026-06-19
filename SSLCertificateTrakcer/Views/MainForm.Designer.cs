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
            addSiteBtn = new Button();
            sslDataGrid = new DataGridView();
            WebsiteColumn = new DataGridViewTextBoxColumn();
            certIssuerDesign = new DataGridViewTextBoxColumn();
            expiryDateCol = new DataGridViewTextBoxColumn();
            daysLeftDesign = new DataGridViewTextBoxColumn();
            certStatusDesign = new DataGridViewTextBoxColumn();
            certificateViewBindingSource = new BindingSource(components);
            statusBar = new StatusStrip();
            sitesTrackedLbl = new ToolStripStatusLabel();
            lblSep1 = new ToolStripStatusLabel();
            expSoonLbl = new ToolStripStatusLabel();
            lblSep2 = new ToolStripStatusLabel();
            expiredLbl = new ToolStripStatusLabel();
            lblSep3 = new ToolStripStatusLabel();
            lastRefreshLbl = new ToolStripStatusLabel();
            rfshAllBtn = new Button();
            rfshSelectedBtn = new Button();
            remSelectedBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)sslDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)certificateViewBindingSource).BeginInit();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // addSiteBtn
            // 
            addSiteBtn.AutoSize = true;
            addSiteBtn.BackColor = Color.FromArgb(35, 122, 254);
            addSiteBtn.FlatAppearance.BorderSize = 0;
            addSiteBtn.FlatStyle = FlatStyle.Flat;
            addSiteBtn.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addSiteBtn.ForeColor = Color.White;
            addSiteBtn.Location = new Point(12, 12);
            addSiteBtn.Name = "addSiteBtn";
            addSiteBtn.Size = new Size(115, 39);
            addSiteBtn.TabIndex = 0;
            addSiteBtn.Text = "+ Add Site";
            addSiteBtn.UseVisualStyleBackColor = false;
            addSiteBtn.Click += addSiteBtnClick;
            // 
            // sslDataGrid
            // 
            sslDataGrid.AllowUserToAddRows = false;
            sslDataGrid.AllowUserToDeleteRows = false;
            sslDataGrid.AllowUserToResizeColumns = false;
            sslDataGrid.AllowUserToResizeRows = false;
            sslDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            sslDataGrid.CellClick += sslDataGrid_CellClick;
            sslDataGrid.CellDoubleClick += sslDataGrid_CellDoubleClick;
            sslDataGrid.CellFormatting += sslDataGrid_CellFormatting;
            sslDataGrid.CellToolTipTextNeeded += sslDataGrid_CellToolTipTextNeeded;
            sslDataGrid.RowPrePaint += sslDataGrid_RowPrePaint;
            sslDataGrid.RowsAdded += sslDataGrid_RowsAdded;
            sslDataGrid.RowsRemoved += sslDataGrid_RowsRemoved;
            sslDataGrid.SelectionChanged += sslDataGrid_SelectionChanged;
            sslDataGrid.MouseClick += sslDataGrid_MouseClick;
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
            // certificateViewBindingSource
            // 
            certificateViewBindingSource.DataSource = typeof(Model.CertificateModel);
            // 
            // statusBar
            // 
            statusBar.AllowMerge = false;
            statusBar.BackColor = Color.FromArgb(35, 122, 254);
            statusBar.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusBar.Items.AddRange(new ToolStripItem[] { sitesTrackedLbl, lblSep1, expSoonLbl, lblSep2, expiredLbl, lblSep3, lastRefreshLbl });
            statusBar.Location = new Point(0, 639);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(1134, 22);
            statusBar.SizingGrip = false;
            statusBar.TabIndex = 1;
            statusBar.MouseClick += statusBar_MouseClick;
            // 
            // sitesTrackedLbl
            // 
            sitesTrackedLbl.ForeColor = Color.White;
            sitesTrackedLbl.Name = "sitesTrackedLbl";
            sitesTrackedLbl.Size = new Size(77, 17);
            sitesTrackedLbl.Text = "sites tracked";
            sitesTrackedLbl.Click += toolStripStatusLabel1_Click;
            // 
            // lblSep1
            // 
            lblSep1.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSep1.ForeColor = Color.White;
            lblSep1.Name = "lblSep1";
            lblSep1.Size = new Size(13, 17);
            lblSep1.Text = "|";
            // 
            // expSoonLbl
            // 
            expSoonLbl.ForeColor = Color.White;
            expSoonLbl.Name = "expSoonLbl";
            expSoonLbl.Size = new Size(81, 17);
            expSoonLbl.Text = "expiring soon";
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
            // rfshAllBtn
            // 
            rfshAllBtn.AutoSize = true;
            rfshAllBtn.BackColor = Color.White;
            rfshAllBtn.FlatAppearance.BorderSize = 0;
            rfshAllBtn.FlatStyle = FlatStyle.Flat;
            rfshAllBtn.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rfshAllBtn.ForeColor = Color.Black;
            rfshAllBtn.Image = (Image)resources.GetObject("rfshAllBtn.Image");
            rfshAllBtn.Location = new Point(133, 12);
            rfshAllBtn.Name = "rfshAllBtn";
            rfshAllBtn.Size = new Size(115, 39);
            rfshAllBtn.TabIndex = 2;
            rfshAllBtn.Text = "Refresh All";
            rfshAllBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            rfshAllBtn.UseVisualStyleBackColor = false;
            rfshAllBtn.Click += rfshAllBtn_Click;
            // 
            // rfshSelectedBtn
            // 
            rfshSelectedBtn.AutoSize = true;
            rfshSelectedBtn.BackColor = Color.White;
            rfshSelectedBtn.FlatAppearance.BorderSize = 0;
            rfshSelectedBtn.FlatStyle = FlatStyle.Flat;
            rfshSelectedBtn.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rfshSelectedBtn.ForeColor = Color.Black;
            rfshSelectedBtn.Image = (Image)resources.GetObject("rfshSelectedBtn.Image");
            rfshSelectedBtn.Location = new Point(254, 12);
            rfshSelectedBtn.Name = "rfshSelectedBtn";
            rfshSelectedBtn.Size = new Size(152, 39);
            rfshSelectedBtn.TabIndex = 3;
            rfshSelectedBtn.Text = "Refresh Selected";
            rfshSelectedBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            rfshSelectedBtn.UseVisualStyleBackColor = false;
            rfshSelectedBtn.Click += rfshSelectedBtn_Click;
            // 
            // remSelectedBtn
            // 
            remSelectedBtn.AutoSize = true;
            remSelectedBtn.BackColor = Color.White;
            remSelectedBtn.FlatAppearance.BorderSize = 0;
            remSelectedBtn.FlatStyle = FlatStyle.Flat;
            remSelectedBtn.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            remSelectedBtn.ForeColor = Color.Black;
            remSelectedBtn.Image = (Image)resources.GetObject("remSelectedBtn.Image");
            remSelectedBtn.Location = new Point(412, 12);
            remSelectedBtn.Name = "remSelectedBtn";
            remSelectedBtn.Size = new Size(154, 39);
            remSelectedBtn.TabIndex = 4;
            remSelectedBtn.Text = "Remove Selected";
            remSelectedBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            remSelectedBtn.UseVisualStyleBackColor = false;
            remSelectedBtn.Click += remSelectedBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(213, 213, 213);
            ClientSize = new Size(1134, 661);
            Controls.Add(remSelectedBtn);
            Controls.Add(rfshSelectedBtn);
            Controls.Add(rfshAllBtn);
            Controls.Add(statusBar);
            Controls.Add(sslDataGrid);
            Controls.Add(addSiteBtn);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(1000, 700);
            Name = "MainForm";
            Text = "SSL Certificate Tracker";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            MouseClick += MainForm_MouseClick;
            ((System.ComponentModel.ISupportInitialize)sslDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)certificateViewBindingSource).EndInit();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addSiteBtn;
        private DataGridView sslDataGrid;
        private StatusStrip statusBar;
        private ToolStripStatusLabel sitesTrackedLbl;
        private ToolStripStatusLabel expSoonLbl;
        private ToolStripStatusLabel expiredLbl;
        private ToolStripStatusLabel lastRefreshLbl;
        private Button rfshAllBtn;
        private Button rfshSelectedBtn;
        private Button remSelectedBtn;
        private ToolStripStatusLabel lblSep1;
        private ToolStripStatusLabel lblSep2;
        private ToolStripStatusLabel lblSep3;
        private BindingSource certificateViewBindingSource;
        private DataGridViewTextBoxColumn WebsiteColumn;
        private DataGridViewTextBoxColumn certIssuerDesign;
        private DataGridViewTextBoxColumn expiryDateCol;
        private DataGridViewTextBoxColumn daysLeftDesign;
        private DataGridViewTextBoxColumn certStatusDesign;
    }
}
