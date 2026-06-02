using SSLCertificateTrakcer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace SSLCertificateTrakcer
{
    public partial class AddSiteForm : Form
    {

        public Uri finalUri {  get; private set; }
        public string UserInput { get; private set; }


        public AddSiteForm()
        {
            InitializeComponent();
        }


        public void addSiteBtn_Form2_Click(object sender, EventArgs e)
        {
            try
            {
                UserInput = WebAddressInput.Text.Trim();

                var builder = new UriBuilder("https", UserInput);

                //Builds the Uri using the Builder
                finalUri = builder.Uri;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (UriFormatException ex) 
            {
                MessageBox.Show("An Error Occured:\n\nWeb Address entered is incorrectly formatted or has illegal charctaers. Hostname could not be parsed from Web Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
