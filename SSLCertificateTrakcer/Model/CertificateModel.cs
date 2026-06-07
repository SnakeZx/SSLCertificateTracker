using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

namespace SSLCertificateTracker.Model
{
    public class CertificateModel
    {
        [JsonInclude]
        public string HostName { get; set; } = string.Empty;
        [JsonInclude]
        public string LastIssuer {  get; private set; } = string.Empty;
        [JsonInclude]
        public DateTime LastExpiryUtc { get; set; }

        public X509Certificate2 Certificate { get; set; }


        public int DaysLeft => (LastExpiryUtc.Date - DateTime.Today).Days;
        public string Status { get; set; } = string.Empty;

        DateTime LastCheckedUtc = DateTime.UtcNow;

        public CertificateModel(X509Certificate2 certificate)
        {
            if (certificate == null) return;
        }
         
 
        public string Issuer { get
            {
                string[] parsedName = Certificate.Issuer.ToString().Split(',');

                for (int i = 0; i < parsedName.Length; i++)
                {
                    if (parsedName[i].Contains("O="))
                    {

                        return parsedName[i].Split('=', StringSplitOptions.TrimEntries)[1];
                    }
                }
            } set; }
        




    }
}
