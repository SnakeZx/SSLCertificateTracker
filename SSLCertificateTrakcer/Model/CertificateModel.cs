using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using SSLCertificateTracker.Enums;

namespace SSLCertificateTracker.Model
{
    public class CertificateModel : INotifyPropertyChanged
    {
        private DateTime _lastExpiryUtc;
        private string _lastIssuer;
        private string _hostName;

        private int _daysLeft;
        private StatusEnums _status;
        private DateTime _lastCheckedUtc;


        #region Json Properties
        [JsonInclude]
        public string HostName
        { get 
            {
                return _hostName;
            }
          set 
            {
                if (_hostName != value)
                {
                    _hostName = value;
                    NotifyPropertyChanged();
                }
            } 
        }
        [JsonInclude]
        public string LastIssuer 
        {
            get 
            {  
                return _lastIssuer; 
            }
            set 
            { 
                if(_lastIssuer != value) 
                {  
                    _lastIssuer = value; 
                    NotifyPropertyChanged(); 
                } 
             } 
        }
        [JsonInclude]
        public DateTime LastExpiryUtc
        {
            get
            {
                return _lastExpiryUtc;
            }
            set
            {
                if (_lastExpiryUtc != value)
                {
                    _lastExpiryUtc = value;
                    NotifyPropertyChanged();
                }
            }
        }
        [JsonIgnore]
        public int DaysLeft
        {
            get
            {
                if (_daysLeft != (LastExpiryUtc.Date - DateTime.Today).Days)
                {
                    _daysLeft = (LastExpiryUtc.Date - DateTime.Today).Days;
                    NotifyPropertyChanged();
                }
                return _daysLeft;
            }
        }
        [JsonIgnore]
        public StatusEnums Status 
        {
            get
            {
                return _status;
            }
            set
            {
                if(Enum.IsDefined(typeof(StatusEnums), value))
                {
                    _status = value;
                    NotifyPropertyChanged();
                }
            }
        }
        [JsonInclude]
        public DateTime LastCheckedUtc 
        { 
            get 
            {
                if (_lastCheckedUtc != DateTime.Now)
                {
                    _lastCheckedUtc = DateTime.Now;
                }

                return _lastCheckedUtc;
            } 
        }

        [JsonInclude]
        public string? LastErrorMessage { get; set; } = null;
        #endregion
           
        [JsonIgnore]
        public X509Certificate2? rawCertificate { get; set; }
        
        [JsonConstructor]
        public CertificateModel() { }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




        public void CalculateStatus()
        {
            if (DaysLeft >= 30 && _status != StatusEnums.Okay)
            {
                _status = StatusEnums.Okay;
                NotifyPropertyChanged();
            }
            else if (DaysLeft < 30 && DaysLeft >= 0 && _status != StatusEnums.ExpiringSoon)
            {
                _status = StatusEnums.ExpiringSoon;
                NotifyPropertyChanged();
            }
            else if (DaysLeft < 0 && _status != StatusEnums.Expired)
            {
                _status = StatusEnums.Expired;
                NotifyPropertyChanged();
            }
        }

        public void SetErrorStatus()
        {
            _status = StatusEnums.Error;
            NotifyPropertyChanged();
        }

        public void SetFetchingStatus()
        {
            _status = StatusEnums.Fetching;
            NotifyPropertyChanged();
        }

    }
        
}
