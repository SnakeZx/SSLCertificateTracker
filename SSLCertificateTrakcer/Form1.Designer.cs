namespace SSLCertificateTrakcer
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            addSiteBtn = new Button();
            sslDataGrid = new DataGridView();
            websiteAddress = new DataGridViewTextBoxColumn();
            certIssuer = new DataGridViewTextBoxColumn();
            expiryDate = new DataGridViewTextBoxColumn();
            daysLeft = new DataGridViewTextBoxColumn();
            certStatus = new DataGridViewTextBoxColumn();
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
            // 
            // sslDataGrid
            // 
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
            sslDataGrid.Columns.AddRange(new DataGridViewColumn[] { websiteAddress, certIssuer, expiryDate, daysLeft, certStatus });
            sslDataGrid.EnableHeadersVisualStyles = false;
            sslDataGrid.GridColor = Color.DarkGray;
            sslDataGrid.Location = new Point(12, 57);
            sslDataGrid.Name = "sslDataGrid";
            sslDataGrid.ReadOnly = true;
            sslDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(218, 237, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            sslDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            sslDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sslDataGrid.ShowEditingIcon = false;
            sslDataGrid.Size = new Size(1110, 576);
            sslDataGrid.TabIndex = 1;
            sslDataGrid.CellContentClick += sslDataGrid_CellContentClick;
            // 
            // websiteAddress
            // 
            websiteAddress.HeaderText = "Website";
            websiteAddress.Name = "websiteAddress";
            websiteAddress.ReadOnly = true;
            // 
            // certIssuer
            // 
            certIssuer.HeaderText = "Issuer";
            certIssuer.Name = "certIssuer";
            certIssuer.ReadOnly = true;
            // 
            // expiryDate
            // 
            expiryDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            expiryDate.FillWeight = 55F;
            expiryDate.HeaderText = "Expiry Date";
            expiryDate.Name = "expiryDate";
            expiryDate.ReadOnly = true;
            // 
            // daysLeft
            // 
            daysLeft.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            daysLeft.HeaderText = "Days Left";
            daysLeft.Name = "daysLeft";
            daysLeft.ReadOnly = true;
            daysLeft.Width = 94;
            // 
            // certStatus
            // 
            certStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            certStatus.FillWeight = 75F;
            certStatus.HeaderText = "Status";
            certStatus.Name = "certStatus";
            certStatus.ReadOnly = true;
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
            // Form1
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
            Name = "Form1";
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
        private DataGridViewTextBoxColumn websiteAddress;
        private DataGridViewTextBoxColumn certIssuer;
        private DataGridViewTextBoxColumn expiryDate;
        private DataGridViewTextBoxColumn daysLeft;
        private DataGridViewTextBoxColumn certStatus;
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
    }
}
