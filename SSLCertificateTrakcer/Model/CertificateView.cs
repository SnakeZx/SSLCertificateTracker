using System;

namespace SSLCertificateTrakcer.Model
{
    public class CertificateView
    {
        public string websiteAddress {  get; set; }

        public string Issuer {  get; set; }
        public DateTime ExpiryDate { get; set; }

        //public string expiryDateFormatted => ExpiryDate.ToString("yyyy-MM-dd");

        public int DaysLeft => (ExpiryDate.Date - DateTime.Today).Days;

    }
}
