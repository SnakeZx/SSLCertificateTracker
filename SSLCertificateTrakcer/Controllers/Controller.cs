using SSLCertificateTracker.Interfaces;
using SSLCertificateTracker.Model;
using SSLCertificateTracker.Services.CertificateService;
using SSLCertificateTracker.Subclass;
using SSLCertificateTracker.Views.MainForm;
using System.Security.Cryptography.X509Certificates;


namespace SSLCertificateTracker.Controllers;

public class Controller
{
    #region Private Readonly Declarations
    private readonly IMainView _view;

    private readonly CertificateModel _model;

    private readonly IFileService _fileService;
    private readonly ICertificateService _certificateService;

    private readonly SortableBindingList<CertificateModel> _list;

    private readonly int port = 443;

    private readonly SemaphoreSlim _semaphoreSlim = new (initialCount: 8, maxCount: 8);
    #endregion

    public Controller(IMainView view, CertificateModel model, IFileService fileService, ICertificateService certificateService)
    {
        _view = view;

        _model = model;

        _fileService = fileService;
        _certificateService = certificateService;

        _list = new SortableBindingList<CertificateModel> ();

        _view.SetDataSource(_list);

        #region Subcribed Events
        _view.OnMainFormLoad += LoadDataRequestAsync;

        _view.OnMainFormClose += SaveListToJsonAsync;

        _view.OnAddNewSiteClick += ShowAddNewSite;
        _view.OnRemoveClick += RemoveSelectedItemAsync;

        _view.OnRefreshSelectedClick += UpdateSelectedRowDataAsync;

        _view.OnRefreshAllClick += UpdateAllDataAsync;

        _view.ViewCertificateData += ShowCertificateData;

        _view.ErrorMesssageTooltip += SetErrorToolTip;
        #endregion
    }

    //Creates addSiteForm to take in user input and return the user input for the Get.
    private async Task ShowAddNewSite()
    {
        using AddSiteForm _UserInputView = new ();

        if (_UserInputView.ShowDialog(_view) == DialogResult.OK)
        {
            await GetCertificateDataAsync(_UserInputView.Userinput);
        }
    }


    //runs when a user clicks confirm on the addsite dialog, and displays the newly created model in the list for the user to view.
    private async Task GetCertificateDataAsync(string userInput)
    {
        CertificateModel NewCertificateData = new ();

        try
        {
            _view.IsFetchingFlag(true);
            userInput = userInput.Trim();
            if(!TryBuildUri(userInput, out Uri? ComputedUri))
            {
                MessageBox.Show($"The entered website: \"{userInput}\" is not vaild hostname please enter a vaild hostname.", "Value Entered Invaild!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!HostNameCheck(ComputedUri!.Host))
            {

                //Creates new certificate model for the view to display 
                NewCertificateData.HostName = ComputedUri.Host;
                NewCertificateData.LastCheckedUtc = DateTime.Now;
                NewCertificateData.SetFetchingStatus();
               
                //adds to list while data is being fetched.
                _list.Add(NewCertificateData);
                var _RawData = await _certificateService.WebConnectAsync(ComputedUri.Host, port);


                NewCertificateData.RawCertificate = _RawData!;
                NewCertificateData.LastIssuer = ExtractIssuer(_RawData!.Issuer);
                NewCertificateData.LastExpiryUtc = _RawData.NotAfter;
                NewCertificateData.CalculateStatus();

                _view.UpdateStatusBarCounts();
                _view.UpdateStatusBarLastRefresh(DateTime.Now);

                //saves the list on a successful path.
                await SaveListToJsonAsync();
            }
            else
            {
                //prompt user for a choice to add another site. If yes a new add site form box appears.
                var result = MessageBox.Show($"This website: {ComputedUri.Host} is already being tracked.\nWould you like to track a different host?", "Already Tracked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                //recurcesl
                if (result == DialogResult.Yes) 
                { 
                    await ShowAddNewSite();
                }
            }

        }
        catch (Exception ex)
        {
            //If there is an error a new row is still made with a tooltip in the status column for what the error is.
            NewCertificateData.HostName = userInput;
            NewCertificateData.LastErrorMessage = ex.Message;
            NewCertificateData.LastExpiryUtc = DateTime.Now;
            NewCertificateData.SetErrorStatus();
        }
        finally
        {
            _view.IsFetchingFlag(false);
        }
    }



    //Updates certificate the model directly with new information if there is any.
    private async Task UpdateCertificateDataAsync(CertificateModel model)
    {
        await _semaphoreSlim.WaitAsync();
        
        try
        {
            string savedHost = model.HostName;

            model.LastErrorMessage = null;
            model.SetFetchingStatus();

            var _RawCertData = await _certificateService.WebConnectAsync(savedHost, port);

            model.RawCertificate = _RawCertData;
            model.HostName = savedHost;
            model.LastIssuer = ExtractIssuer(_RawCertData!.Issuer);
            model.LastExpiryUtc = _RawCertData.NotAfter;
            model.LastCheckedUtc = DateTime.Now;
            model.CalculateStatus();

            _view.UpdateStatusBarCounts();
            _view.UpdateStatusBarLastRefresh(DateTime.Now);
        }
        catch (Exception ex)
        {
            model.LastExpiryUtc = DateTime.Now;
            model.SetErrorStatus();
            model.LastErrorMessage = ex.Message;
        }
        finally
        {
            _semaphoreSlim.Release();
        }

    }

    private async Task UpdateAllDataAsync()
    {
        _view.IsFetchingFlag(true);
        //take a Snapshot of the list to safely handle the Async Update if a user adds or removes an Item from the list.
        var temp = _list.ToList();

        var task = new List<Task>();

        foreach (CertificateModel item in temp)
        {
            task.Add(UpdateCertificateDataAsync(item));
        }

        await Task.WhenAll(task);


        _view.IsFetchingFlag(false);
        _view.UpdateStatusBarLastRefresh(DateTime.Now);

        await SaveListToJsonAsync();
        
    }

    //Updates calls the update selected row Async function and passes the row the user has highlighted to pass the model over
    private async Task UpdateSelectedRowDataAsync(int index)
    {
        _view.IsFetchingFlag(true);
        await UpdateCertificateDataAsync(_list[index]);

        _view.IsFetchingFlag(false);
        _view.UpdateStatusBarLastRefresh(DateTime.Now);
        await SaveListToJsonAsync();
    }

    //Removes Selected Row from the list and saves a new Json file to remove it from the file
    private async Task RemoveSelectedItemAsync(int index)
    {
        var result = MessageBox.Show($"Would you like to stop tracking {_list[index].HostName}?", "Are You Sure?", MessageBoxButtons.YesNo);

        if (result == DialogResult.No) return;

        _list.RemoveAt(index);
        _view.UpdateStatusBarCounts();
        await SaveListToJsonAsync();
    }

    //Checks if the userinput hostname is already in the list. returns true if its found in the list;
    private bool HostNameCheck(string hostname)
    {
        bool exists = false;

        foreach (var item in _list)
        {
            if (string.Equals(item.HostName, hostname, StringComparison.OrdinalIgnoreCase))
            {
                exists = true;
                break;
            }
        }

        return exists;
    }

    //Calls the file service class to save the list in an Async manner.
    private async Task SaveListToJsonAsync()
    {
        await _fileService.SaveAsync(_list);
    }

    //Async function that Loads the data from disk in an async manner and uses the snapshot of the list (temp) to update all the objects with new updated data.
    private async Task LoadDataRequestAsync()
    {
        _view.IsFetchingFlag(true);
        var temp = await _fileService.GetAllAsync();

        if (temp.Count == 0) return;
        try
        {
            foreach (CertificateModel item in temp)
            {
                item.LastErrorMessage = null;
                _list.Add(item);
            }


            var task = new List<Task>();
            foreach (CertificateModel item in temp)
            {
                task.Add(UpdateCertificateDataAsync(item));
            }
            
            await Task.WhenAll(task);
        }
        finally
        {
            _view.OnMainFormLoad -= LoadDataRequestAsync;
            _view.IsFetchingFlag(false);
        }

    }

    //Handles the event of a User double clicking on a Hostname cell and displaying the certificate using windows built in dialog for showing certificate information
    private async Task ShowCertificateData(int index)
    {
        if(_list[index].RawCertificate != null)
        {
            X509Certificate2UI.DisplayCertificate(_list[index].RawCertificate!, _view.Handle);
        }
        else
        {
            MessageBox.Show("The selected row does not have a valid certificate to view. Please select another row or refresh the list if this is a mistake.","Certificate Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        
    }

    //Returns the error message to the view to use as a tooltip. 
    private string SetErrorToolTip(int index)
    {
        if (index < 0) { return string.Empty; }

        if (_list[index].LastErrorMessage == null)
        {
            return string.Empty;
        }

        return _list[index].LastErrorMessage!;

    }

    public static bool TryBuildUri(string rawinput, out Uri? computedUri)
    {
        bool success = false;
        string _rawInput = rawinput;
        computedUri = null;

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
           computedUri = validuri;
           success = true;
        }
        
        return success;
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
}
