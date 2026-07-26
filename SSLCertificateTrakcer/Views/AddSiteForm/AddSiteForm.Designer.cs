namespace SSLCertificateTracker
{
    partial class AddSiteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddSiteConfirm = new Button();
            cancelBtn_Form2 = new Button();
            WebAddressInput = new TextBox();
            EnterWebAddressLbl = new Label();
            CharacterErrorLbl = new Label();
            SuspendLayout();
            // 
            // AddSiteConfirm
            // 
            AddSiteConfirm.AutoSize = true;
            AddSiteConfirm.BackColor = Color.FromArgb(35, 122, 254);
            AddSiteConfirm.FlatAppearance.BorderSize = 0;
            AddSiteConfirm.FlatStyle = FlatStyle.Flat;
            AddSiteConfirm.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddSiteConfirm.ForeColor = Color.White;
            AddSiteConfirm.Location = new Point(97, 160);
            AddSiteConfirm.Name = "AddSiteConfirm";
            AddSiteConfirm.Size = new Size(115, 39);
            AddSiteConfirm.TabIndex = 1;
            AddSiteConfirm.Text = "Confirm";
            AddSiteConfirm.UseVisualStyleBackColor = false;
            AddSiteConfirm.Click += AddSiteConfirmClick;
            // 
            // cancelBtn_Form2
            // 
            cancelBtn_Form2.AutoSize = true;
            cancelBtn_Form2.BackColor = Color.White;
            cancelBtn_Form2.FlatAppearance.BorderSize = 0;
            cancelBtn_Form2.FlatStyle = FlatStyle.Flat;
            cancelBtn_Form2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn_Form2.ForeColor = Color.Black;
            cancelBtn_Form2.Location = new Point(255, 160);
            cancelBtn_Form2.Name = "cancelBtn_Form2";
            cancelBtn_Form2.Size = new Size(115, 39);
            cancelBtn_Form2.TabIndex = 3;
            cancelBtn_Form2.Text = "Cancel";
            cancelBtn_Form2.TextImageRelation = TextImageRelation.ImageBeforeText;
            cancelBtn_Form2.UseVisualStyleBackColor = false;
            cancelBtn_Form2.Click += cancelBtn_Form2_Click;
            // 
            // WebAddressInput
            // 
            WebAddressInput.Location = new Point(97, 80);
            WebAddressInput.MaxLength = 64;
            WebAddressInput.Multiline = true;
            WebAddressInput.Name = "WebAddressInput";
            WebAddressInput.PlaceholderText = "(e.g. example.com, https://example.com)";
            WebAddressInput.Size = new Size(273, 23);
            WebAddressInput.TabIndex = 4;
            // 
            // EnterWebAddressLbl
            // 
            EnterWebAddressLbl.AutoSize = true;
            EnterWebAddressLbl.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EnterWebAddressLbl.Location = new Point(158, 37);
            EnterWebAddressLbl.Name = "EnterWebAddressLbl";
            EnterWebAddressLbl.Size = new Size(143, 19);
            EnterWebAddressLbl.TabIndex = 5;
            EnterWebAddressLbl.Text = "Enter Web Address:";
            // 
            // CharacterErrorLbl
            // 
            CharacterErrorLbl.AutoSize = true;
            CharacterErrorLbl.BackColor = Color.Transparent;
            CharacterErrorLbl.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CharacterErrorLbl.ForeColor = Color.Red;
            CharacterErrorLbl.Location = new Point(133, 123);
            CharacterErrorLbl.Name = "CharacterErrorLbl";
            CharacterErrorLbl.Size = new Size(0, 15);
            CharacterErrorLbl.TabIndex = 6;
            CharacterErrorLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddSiteForm
            // 
            AcceptButton = AddSiteConfirm;
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 213, 213);
            CancelButton = cancelBtn_Form2;
            ClientSize = new Size(454, 211);
            ControlBox = false;
            Controls.Add(CharacterErrorLbl);
            Controls.Add(EnterWebAddressLbl);
            Controls.Add(WebAddressInput);
            Controls.Add(cancelBtn_Form2);
            Controls.Add(AddSiteConfirm);
            Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(470, 250);
            MinimizeBox = false;
            MinimumSize = new Size(470, 250);
            Name = "AddSiteForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Site";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddSiteConfirm;
        private Button cancelBtn_Form2;
        private TextBox WebAddressInput;
        private Label EnterWebAddressLbl;
        private Label CharacterErrorLbl;
    }
}