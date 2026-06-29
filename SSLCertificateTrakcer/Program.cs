using SSLCertificateTracker.Controllers;
using SSLCertificateTracker.Model;
using System.Diagnostics;


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
            //AppDomain.CurrentDomain.UnhandledException += 
            //    (sender, e) => 
            //    { 
            //        System.IO.File.WriteAllText("crash.txt", e.ToString());
            //        MessageBox.Show($"An unexpected error occured:\n{e.ToString()}\nThe application will need to be restarted.\n", "Unexpected Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    };
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

            Controller controller = new(view, model);

            Application.Run(view);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show($"An Unexpected Application Error Occured:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}\n\nPlease restart the application.", "Unexpected Application Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}