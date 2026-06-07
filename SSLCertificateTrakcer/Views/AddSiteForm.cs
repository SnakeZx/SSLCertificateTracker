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

            AddSiteConfirm.Click += AddSiteConfirmClick;

        }


        public void AddSiteConfirmClick(object? sender, EventArgs e)
        {
            //Takes user input and builds a URI using the Uri Builder I defined so all links come out the same.

            //if (!UserInput.Contains(":")) 
            //{
            //    UserInput = "https://" + UserInput;
            //}

            //if (Uri.IsWellFormedUriString(UserInput, UriKind.Absolute)) 
            //{
            //    FinalUri = new Uri(UserInput);
            //}

            //if (FinalUri.Scheme != "https")
            //{
            //    /*Catches Formating of the User input and prompts a MessageBox with an Ok button
            //      this is to let the user know the address they entered is not formatted correctly or has illegal charachters that cannot be in a web address.*/
            //    MessageBox.Show("An Error Occured:\n\nWeb Address entered is incorrectly formatted or has illegal charctaers. Hostname could not be parsed from Web Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            OnUserInputConfirm?.Invoke(WebAddressInput.Text);
            //OnConfirmSave?.Invoke();

            //DialogResult = DialogResult.OK;
            //Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Form2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
