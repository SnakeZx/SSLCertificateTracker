using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

namespace SSLCertificateTrakcer.Model
{
    public class CertificateView
    {
        [JsonInclude]
        public string HostName { get; set; } = string.Empty;
        [JsonInclude]
        public string LastIssuer {  get; set; } = string.Empty;
        [JsonInclude]
        public DateTime LastExpiryUtc { get; set; }
        public int DaysLeft => (LastExpiryUtc.Date - DateTime.Today).Days;
        
        public string Status { get; set; } = string.Empty;

        DateTime LastCheckedUtc = DateTime.UtcNow;

        public CertificateView(X509Certificate2 cert, string website)
        {
            LastExpiryUtc = cert.NotAfter;

            HostName = website;

            LastIssuer = ExtractIssuer(cert.Issuer.ToString());

            Status = "\u26A0 Warning";
        }


        private static string ExtractIssuer(string IssuerName)
        {

            string defaultVal = "Issuer Could not be found in X5902 Data";

            string[] parsedName = IssuerName.Split(',');

            for (int i = 0; i < parsedName.Length; i++) {
                if (parsedName[i].Contains("O=")){
                    
                   return parsedName[i].Split('=', StringSplitOptions.TrimEntries)[1];
                }
            }

            return defaultVal;
        }

    }
}
