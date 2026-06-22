using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using SSLCertificateTracker.Enums;

namespace SSLCertificateTracker.Model
{
    public class CertificateModel : INotifyPropertyChanged
    {
        #region Json Properties
        [JsonInclude]
        public string HostName { get; set; } = string.Empty;
        [JsonInclude]
        public string LastIssuer { get; set; } = string.Empty;
        [JsonInclude]
        public DateTime LastExpiryUtc { get; set; } = DateTime.Today;
        [JsonInclude]
        public DateTime LastCheckedUtc = DateTime.Now;
        [JsonInclude]
        public string? LastErrorMessage { get; set; } = null;
        #endregion

        [JsonIgnore]
        public Uri? ComputedUri { get; set; }
        [JsonIgnore]
        public int DaysLeft => (LastExpiryUtc.Date - DateTime.Today).Days;
        [JsonIgnore]
        public Enum Status { get; set; } = StatusEnums.fetching;
        [JsonIgnore]
        public X509Certificate2 rawCertificate { get; set; }
        
        private string _rawInput = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        [JsonConstructor]
        public CertificateModel()
        {
        }


        public bool TryBuildUri(string rawinput)
        {
            _rawInput = rawinput.Trim();

            if (string.IsNullOrWhiteSpace(rawinput))
            {
                return false;
            }

            if (!_rawInput.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                !_rawInput.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                _rawInput = "https://" + _rawInput;
            }
            else if (_rawInput.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                _rawInput = _rawInput.Substring(7);
                _rawInput = "https://" + _rawInput;

            }

            if (Uri.TryCreate(_rawInput, UriKind.Absolute, out Uri? validuri))
            {
                ComputedUri = validuri;
                return true;
            }
            else
            {
                return false;
            }
        }

        //replaces all quotes in the string with a space. looks for the organization column
        public string ExtractIssuer(string Issuer)
            {
                Issuer = Issuer.Replace('"', ' ');
                string[] ExtractedNames = Issuer.Split(',');

                for (int i = 0; i < ExtractedNames.Length; i++)
                {
                    if (ExtractedNames[i].Contains("O="))
                    {
                        return ExtractedNames[i].Split('=', StringSplitOptions.TrimEntries)[1];
                    }
                }
            return string.Empty;
        }

        public StatusEnums GetStatus()
        {
            if(DaysLeft >= 30)
            {
                return StatusEnums.Okay;
            }
            else if (DaysLeft < 30 && DaysLeft > 0)
            {
                return StatusEnums.ExpiringSoon;
            }
            else
            {
                return StatusEnums.Expired;
            }
        }

        public StatusEnums SetErrorStatus()
        {
            return StatusEnums.Error;
        }

        public StatusEnums SetFetchingStatus()
        {
            return StatusEnums.fetching;
        }

        //        if(DaysLeft >= 30)
        //{
        //    return "\U0001F7E2 OK";
        //}
        //else if (DaysLeft< 30 && DaysLeft> 0)
        //{
        //    return "\U000026A0\U0000FE0F Expiring Soon";
        //}
        //else
        //{
        //    return "\U0001F6AB Expired";
        //}




    }
        
}
