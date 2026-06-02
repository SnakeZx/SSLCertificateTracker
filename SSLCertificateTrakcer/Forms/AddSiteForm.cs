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
            Debug.WriteLine($"AddSiteForm constructor at {DateTime.Now:HH:mm:ss.fff}");
        }


        public void addSiteBtn_Form2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"submitBtn_Click entered at {DateTime.Now:HH:mm:ss.fff}");
            UserInput = WebAddressInput.Text.Trim();

                var builder = new UriBuilder("https", UserInput);

                //Builds the Uri using the Builder
                finalUri = builder.Uri;

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
    }
}
