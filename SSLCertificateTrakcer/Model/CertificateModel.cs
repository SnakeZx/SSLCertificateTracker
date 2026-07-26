using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using SSLCertificateTracker.Enums;

namespace SSLCertificateTracker.Model;
public class CertificateModel : INotifyPropertyChanged
{
    private DateTime _lastExpiryUtc;
    private string _lastIssuer = string.Empty;
    private string _hostName = string.Empty;

    private int _daysLeft = 0;
    private StatusEnum _status = StatusEnum.Fetching;
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
                UpdateDaysLeft();
                NotifyPropertyChanged();
            }
        }
    }
    [JsonIgnore]
    public int DaysLeft
    {
        get
        {
            return _daysLeft;
        }
        set
        {
            if(_daysLeft != value)
            {
                _daysLeft = value;
                NotifyPropertyChanged();
            }
        }
    }
    [JsonIgnore]
    public StatusEnum Status 
    {
        get
        {
            return _status;
        }
        set
        {
            if(Enum.IsDefined(typeof(StatusEnum), value))
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
            return _lastCheckedUtc;
        }
        set
        {
            if(_lastCheckedUtc != value)
            {
                _lastCheckedUtc = value;
            }
        }
    }

    [JsonInclude]
    public string? LastErrorMessage { get; set; } = null;
    #endregion
       
    [JsonIgnore]
    public X509Certificate2? RawCertificate { get; set; }
    
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

    public void UpdateDaysLeft()
    {
            _daysLeft = (LastExpiryUtc.Date - DateTime.Today).Days;
    }


    public void CalculateStatus()
    {
        if (DaysLeft >= 30 && _status != StatusEnum.Okay)
        {
            _status = StatusEnum.Okay;
            NotifyPropertyChanged();
        }
        else if (DaysLeft < 30 && DaysLeft >= 0 && _status != StatusEnum.ExpiringSoon)
        {
            _status = StatusEnum.ExpiringSoon;
            NotifyPropertyChanged();
        }
        else if (DaysLeft < 0 && _status != StatusEnum.Expired)
        {
            _status = StatusEnum.Expired;
            NotifyPropertyChanged();
        }
    }

    public void SetErrorStatus()
    {
        _status = StatusEnum.Error;
        NotifyPropertyChanged();
    }

    public void SetFetchingStatus()
    {
        _status = StatusEnum.Fetching;
        NotifyPropertyChanged();
    }

}
    
