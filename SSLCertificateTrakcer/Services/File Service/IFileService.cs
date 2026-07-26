using SSLCertificateTracker.Model;
using SSLCertificateTracker.Subclass;

namespace SSLCertificateTracker.Interfaces;

public interface IFileService
{
    Task SaveAsync(SortableBindingList<CertificateModel> list);
    Task<SortableBindingList<CertificateModel>> GetAllAsync();
}
