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

        private MainForm mainForm = new MainForm();

        ////Creates a new object for my created class that can be called from here when actions are preformed.
        private CertificateService certificateService = new CertificateService();
        private X509Certificate2 certificateResult;

        ////Hardcoded Port and string for the TcpClient Connection.
        public int port = 443;
        //public string serverName = "www.judicatewest.com";


        public AddSiteForm()
        {
            InitializeComponent();
        }


        private async void addSiteBtn_Form2_Click(object sender, EventArgs e)
        {
            try
            {
                string UserInput = WebAddressInput.Text.Trim();

                //if(Uri.TryCreate(UserInput, UriKind.Absolute, out Uri result))
                //{
                //    if(result.Scheme == Uri.UriSchemeHttps)
                //    {
                //        certificateResult = await certificateService.WebConnectAsync(result.Host, port);
                //    }
                //    else if(new)
                //    {
                //        UserInput = "https://" + WebAddressInput.Text;
                //    }
                //}

                //Uri UserInputUri = new Uri(UserInput);

                //UriBuilder builder = new UriBuilder(UserInputUri);

                //builder.Scheme = "https";

                //Uri SecureUri = builder.Uri;

                //Uses Uri Builder to make the web address using https:// not entirely necessary
                var builder = new UriBuilder("https", UserInput);
                
                //Builds the Uri using the Builder
                Uri finalUri = builder.Uri;

                Debug.WriteLine(finalUri);
                Debug.WriteLine(finalUri.Host);

                Debug.WriteLine("Connecting ....");

                certificateResult = await certificateService.WebConnectAsync(finalUri.Host, port);

                Debug.WriteLine("Connected To: " + UserInput + " - On Port: " + port);

                mainForm.LoadCertificate(certificateResult, UserInput);

                this.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Error: {0}", ex);
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
