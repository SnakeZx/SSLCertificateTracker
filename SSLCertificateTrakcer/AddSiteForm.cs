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
    //Creates a new object for my created class that can be called from here when actions are preformed.
    private CertificateService certificateService = new CertificateService();
    private X509Certificate2 certificateResult;

    //Hardcoded Port and string for the TcpClient Connection.
    public int port = 443;
    public string serverName = "www.judicatewest.com";
        
        
        public AddSiteForm()
        {
            InitializeComponent();
        }


        private async void addSiteBtn_Form2_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Connecting ....");

                certificateResult = await certificateService.ConnectAsync(serverName, port);

                Debug.WriteLine("Connected To: " + serverName + " - On Port: " + port);

                Debug.WriteLine(certificateResult.NotAfter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Error: {0}", ex);
                certificateResult = null;
                return;
            }
        }
    }
}
