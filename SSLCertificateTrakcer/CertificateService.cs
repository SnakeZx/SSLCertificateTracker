using System;
using System.Diagnostics;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
namespace SSLCertificateTrakcer
{
    internal class CertificateService
    {

        public async Task ConnectAsync(string server, int Port)
        {
            try
            {

                using TcpClient client = new TcpClient(server, Port);
                Debug.WriteLine("Connected to {0}", server);

                //SslStream sslStream = new SslStream(client.GetStream(), false, null, null);
                //Console.WriteLine("Stream Open");

                //X509Certificate2 cert = new X509Certificate2(sslStream.RemoteCertificate);

            }
            catch(SocketException e)
            {
                Debug.WriteLine("Socket Expection: {0}", e);
                return;
            }

        }
    }
}
