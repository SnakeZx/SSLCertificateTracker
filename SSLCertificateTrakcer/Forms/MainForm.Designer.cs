namespace SSLCertificateTrakcer
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
            if(disposing && (certificateResult != null))
            {
                certificateResult.Dispose();
            }

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            addSiteBtn = new Button();
            sslDataGrid = new DataGridView();
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
            websiteAddressDesign = new DataGridViewTextBoxColumn();
            certIssuerDesign = new DataGridViewTextBoxColumn();
            expiryDateCol = new DataGridViewTextBoxColumn();
            daysLeftDesign = new DataGridViewTextBoxColumn();
            certStatusDesign = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)sslDataGrid).BeginInit();
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
            addSiteBtn.Click += addSiteBtn_Click;
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
            sslDataGrid.Columns.AddRange(new DataGridViewColumn[] { websiteAddressDesign, certIssuerDesign, expiryDateCol, daysLeftDesign, certStatusDesign });
            sslDataGrid.EnableHeadersVisualStyles = false;
            sslDataGrid.GridColor = Color.DarkGray;
            sslDataGrid.Location = new Point(12, 57);
            sslDataGrid.Name = "sslDataGrid";
            sslDataGrid.ReadOnly = true;
            sslDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(218, 237, 254);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            sslDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            sslDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sslDataGrid.ShowEditingIcon = false;
            sslDataGrid.Size = new Size(1110, 576);
            sslDataGrid.TabIndex = 1;
            sslDataGrid.CellContentClick += sslDataGrid_CellContentClick;
            // 
            // statusBar
            // 
            statusBar.BackColor = Color.FromArgb(35, 122, 254);
            statusBar.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusBar.Items.AddRange(new ToolStripItem[] { sitesTrackedLbl, lblSep1, expSoonLbl, lblSep2, expiredLbl, lblSep3, lastRefreshLbl });
            statusBar.Location = new Point(0, 639);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(1134, 22);
            statusBar.SizingGrip = false;
            statusBar.TabIndex = 1;
            statusBar.ItemClicked += statusBar_ItemClicked;
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
            // 
            // websiteAddressDesign
            // 
            websiteAddressDesign.DataPropertyName = "websiteAddress";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            websiteAddressDesign.DefaultCellStyle = dataGridViewCellStyle2;
            websiteAddressDesign.HeaderText = "Website";
            websiteAddressDesign.Name = "websiteAddressDesign";
            websiteAddressDesign.ReadOnly = true;
            // 
            // certIssuerDesign
            // 
            certIssuerDesign.DataPropertyName = "Issuer";
            certIssuerDesign.HeaderText = "Issuer";
            certIssuerDesign.Name = "certIssuerDesign";
            certIssuerDesign.ReadOnly = true;
            // 
            // expiryDateCol
            // 
            expiryDateCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            expiryDateCol.DataPropertyName = "ExpiryDate";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            expiryDateCol.DefaultCellStyle = dataGridViewCellStyle3;
            expiryDateCol.FillWeight = 55F;
            expiryDateCol.HeaderText = "Expiry Date";
            expiryDateCol.Name = "expiryDateCol";
            expiryDateCol.ReadOnly = true;
            // 
            // daysLeftDesign
            // 
            daysLeftDesign.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            daysLeftDesign.DataPropertyName = "daysLeft";
            daysLeftDesign.HeaderText = "Days Left";
            daysLeftDesign.Name = "daysLeftDesign";
            daysLeftDesign.ReadOnly = true;
            daysLeftDesign.Width = 94;
            // 
            // certStatusDesign
            // 
            certStatusDesign.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            certStatusDesign.DataPropertyName = "certStatus";
            certStatusDesign.FillWeight = 75F;
            certStatusDesign.HeaderText = "Status";
            certStatusDesign.Name = "certStatusDesign";
            certStatusDesign.ReadOnly = true;
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
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)sslDataGrid).EndInit();
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
        private DataGridViewTextBoxColumn websiteAddressDesign;
        private DataGridViewTextBoxColumn certIssuerDesign;
        private DataGridViewTextBoxColumn expiryDateCol;
        private DataGridViewTextBoxColumn daysLeftDesign;
        private DataGridViewTextBoxColumn certStatusDesign;
    }
}
