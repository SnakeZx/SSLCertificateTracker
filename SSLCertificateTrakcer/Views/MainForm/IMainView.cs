using SSLCertificateTracker.Model;
using SSLCertificateTracker.Subclass;
using System.Windows.Forms;

namespace SSLCertificateTracker.Views.MainForm;

public interface IMainView: IWin32Window
{
    public event Func<Task>? OnMainFormLoad;
    public event Func<Task>? OnMainFormClose;

    public event Func<Task>? OnAddNewSiteClick;
    public event Func<Task>? OnRefreshAllClick;
    public event Func<int, Task>? OnRefreshSelectedClick;
    public event Func<int, Task>? OnRemoveClick;
    public event Func<int, Task>? ViewCertificateData;
    public event Func<int, string>? ErrorMesssageTooltip;


    public void IsFetchingFlag(bool isFetching);
    public void UpdateStatusBarCounts();
    public void UpdateStatusBarLastRefresh(DateTime dt);
    public void SetDataSource(SortableBindingList<CertificateModel> list);

}
