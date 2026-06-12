using System.Text.Json.Serialization;

namespace SSLCertificateTracker.Model
{
    public class CertificateModel
    {
        [JsonInclude]
        public string HostName { get; set; } = string.Empty;
        [JsonInclude]
        public string LastIssuer { get; set; } = string.Empty;
        [JsonInclude]
        public DateTime LastExpiryUtc { get; set; } = DateTime.Today;
        [JsonIgnore]
        public Uri? ComputedUri { get; set; }
        [JsonIgnore]
        public int DaysLeft => (LastExpiryUtc.Date - DateTime.Today).Days;
        [JsonIgnore]
        public string Status { get; set; } = string.Empty;

        DateTime LastCheckedUtc = DateTime.UtcNow;

        private string _rawInput = string.Empty;

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


        public string ExtractIssuer(string Issuer)
            {
                string[] ExtractedName = Issuer.Split(',');

                for (int i = 0; i < ExtractedName.Length; i++)
                {
                    if (ExtractedName[i].Contains("O="))
                    {

                        return ExtractedName[i].Split('=', StringSplitOptions.TrimEntries)[1];
                    }
                }
            return string.Empty;
        }

        public string GetStatus()
        {
            if(DaysLeft >= 30)
            {
                return "\U0001F7E2 OK";
            }
            else if (DaysLeft < 30 && DaysLeft > 0)
            {
                return "\U000026A0\U0000FE0F Expiring Soon";
            }
            else
            {
                return "\u274C Expired";
            }
        }

        public string SetError()
        {
            return $"\u274C Error";
        }


    }
        
}
