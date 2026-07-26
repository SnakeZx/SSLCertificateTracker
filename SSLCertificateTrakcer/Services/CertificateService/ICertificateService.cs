using System.Security.Cryptography.X509Certificates;

namespace SSLCertificateTracker.Services.CertificateService;

public interface ICertificateService
{
    Task<X509Certificate2?> WebConnectAsync(string server, int Port);
}
