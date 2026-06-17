using SSLCertificateTracker.Controllers;
using SSLCertificateTracker.Model;


namespace SSLCertificateTracker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            MainForm view = new ();

            CertificateModel model = new ();

            Controller controller = new(view, model);

            Application.Run(view);
        }
    }
}