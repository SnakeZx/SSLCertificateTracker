using System;
using System.Diagnostics;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
namespace SSLCertificateTracker.Services
{
    internal class CertificateService
    {
        //Declare Objects that I am using to intatiate a connections to the server.

        public async Task<X509Certificate2> WebConnectAsync(string server, int Port)
        {

                RemoteCertificateValidationCallback certCallBack = (_, _, _, _) => true;

                //creates the TCP connection to the given server and port.
                using TcpClient _client = new TcpClient();
                await _client.ConnectAsync(server, Port);
                Debug.WriteLine("Connection Established");

                //Opens a SslStream and gets the networkstream from the _client object.
                using SslStream _stream = new SslStream(_client.GetStream(), false, certCallBack, null);

                await _stream.AuthenticateAsClientAsync(server);

                Debug.WriteLine("Stream Established & Authenticated");

                if(_stream.RemoteCertificate is X509Certificate2 remoteCert)
                {
                    return new X509Certificate2(remoteCert);
                }
            throw new Exception("Error - Something Went Wrong and a Certificate Could not be found.");
        }
    }
}
