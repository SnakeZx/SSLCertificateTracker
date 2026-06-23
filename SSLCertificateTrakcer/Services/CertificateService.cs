using System.Diagnostics;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
namespace SSLCertificateTracker.Services
{
    internal class CertificateService
    {
        public static async Task<X509Certificate2?> WebConnectAsync(string server, int Port)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(10);

            RemoteCertificateValidationCallback certCallBack = (_, _, _, _) => true;

            //creates the TCP connection to the given server and port.
            using TcpClient _client = new TcpClient();

            using CancellationTokenSource connectCts = new CancellationTokenSource(timeout);
            try
            {
                await _client.ConnectAsync(server, Port, connectCts.Token);

            }
            catch(OperationCanceledException)
            {
                throw new TimeoutException("The Tcp Connection attempt timed out.");
            }

            //Opens a SslStream and gets the networkstream from the _client object.
            using SslStream _stream = new SslStream(_client.GetStream(), false, certCallBack);

            using CancellationTokenSource handshakeCts = new CancellationTokenSource(timeout);
            try
            {
                await _stream.AuthenticateAsClientAsync(new SslClientAuthenticationOptions
                {
                    TargetHost = server
                }, handshakeCts.Token);


                if (_stream.RemoteCertificate is X509Certificate2 remoteCert)
                {
                    return new X509Certificate2(remoteCert);
                }
            }
            catch (OperationCanceledException)
            {
                throw new TimeoutException("The TLS handshake timed out.");
            }

            return null;
        }
    }
}
