using SSLCertificateTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace SSLCertificateTracker
{
    public partial class AddSiteForm : Form
    {
        public event Action<string>? OnUserInputConfirm;

        public event Action? OnConfirmSave;
        //Trims the web address the user input to get rid of spaces/whitespace before and after the user input.
        //public Uri FinalUri { get; private set; } = new Uri("about:blank");
        //public string UserInput { get; private set; } = string.Empty;


        public AddSiteForm()
        {
            InitializeComponent();

        }


        public void AddSiteConfirmClick(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WebAddressInput.Text))
            {
                CharacterErrorLbl.Text = "Empty line or spaces are not valid.";
                return;
            }

            OnUserInputConfirm?.Invoke(WebAddressInput.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Form2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
