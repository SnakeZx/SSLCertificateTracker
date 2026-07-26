using SSLCertificateTracker.Controllers;
using SSLCertificateTracker.Interfaces;
using SSLCertificateTracker.Model;
using SSLCertificateTracker.Services;
using SSLCertificateTracker.Services.CertificateService;
using SSLCertificateTracker.Views.MainForm;


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

            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            
            ApplicationConfiguration.Initialize();

            MainForm view = new ();

            Application.ThreadException += new ThreadExceptionEventHandler(view.BackgroundThreadsUnhandledExceptionsHandler);

            CertificateModel model = new ();

            IFileService fileService = new FileService();
            ICertificateService certificateService = new CertificateService();
            IMainView viewInterface = view;

            Controller controller = new(viewInterface, model, fileService, certificateService);

            Application.Run(view);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show($"An Unexpected Application Error Occured:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}\n\nPlease restart the application.", "Unexpected Application Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}