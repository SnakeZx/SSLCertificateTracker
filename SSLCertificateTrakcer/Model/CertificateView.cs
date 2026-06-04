using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SSLCertificateTrakcer.Model
{
    public class CertificateView
    {
        public string websiteAddress { get; set; } = string.Empty;

        public string Issuer {  get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        public int DaysLeft => (ExpiryDate.Date - DateTime.Today).Days;

        public string Status { get; set; } = string.Empty;

        public CertificateView(X509Certificate2 cert, string website)
        {
            ExpiryDate = cert.NotAfter;

            websiteAddress = website;

            Issuer = ExtractIssuer(cert.IssuerName);

            Status = "\u26A0 Warning";
        }

        private static string ExtractIssuer(X500DistinguishedName IssuerName)
        {

            string defaultVal = "Issuer Could not be found in X5902 Data";

            string[] parsedName = IssuerName.Name.Split(',');

            for (int i = 0; i < parsedName.Length; i++) {
                if (parsedName[i].Contains("O=")){
                    
                   return parsedName[i].Split('=', StringSplitOptions.TrimEntries)[1];
                }
            }

            return defaultVal;
        }

    }
}
