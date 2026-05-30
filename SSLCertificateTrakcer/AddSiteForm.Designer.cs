namespace SSLCertificateTrakcer
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
            addSiteBtn_Form2 = new Button();
            cancelBtn_Form2 = new Button();
            SuspendLayout();
            // 
            // addSiteBtn_Form2
            // 
            addSiteBtn_Form2.AutoSize = true;
            addSiteBtn_Form2.BackColor = Color.FromArgb(35, 122, 254);
            addSiteBtn_Form2.FlatAppearance.BorderSize = 0;
            addSiteBtn_Form2.FlatStyle = FlatStyle.Flat;
            addSiteBtn_Form2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addSiteBtn_Form2.ForeColor = Color.White;
            addSiteBtn_Form2.Location = new Point(97, 160);
            addSiteBtn_Form2.Name = "addSiteBtn_Form2";
            addSiteBtn_Form2.Size = new Size(115, 39);
            addSiteBtn_Form2.TabIndex = 1;
            addSiteBtn_Form2.Text = "+ Add Site";
            addSiteBtn_Form2.UseVisualStyleBackColor = false;
            addSiteBtn_Form2.Click += addSiteBtn_Form2_Click;
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
            // 
            // AddSiteForm
            // 
            AcceptButton = addSiteBtn_Form2;
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 213, 213);
            CancelButton = cancelBtn_Form2;
            ClientSize = new Size(454, 211);
            ControlBox = false;
            Controls.Add(cancelBtn_Form2);
            Controls.Add(addSiteBtn_Form2);
            Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(470, 250);
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

        private Button addSiteBtn_Form2;
        private Button cancelBtn_Form2;
    }
}