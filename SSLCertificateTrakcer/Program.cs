using SSLCertificateTracker.Controllers;
using SSLCertificateTracker.Model;


namespace SSLCertificateTracker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        private static Mutex? mutex = null;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            const string appName = "Global\\SSLCertTracker_e2ac32f9-9ccb-4d3f-b84c-f65fbca85cfb";

            mutex = new Mutex(true, appName, out bool createdNew);
            
            if (!createdNew)
            {
                // Another instance is already running; warn the user and exit
                MessageBox.Show("The application is already running.", "Instance Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            mutex.ReleaseMutex();
            mutex.Dispose();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show($"An Unexpected Application Error Occured:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}\n\nPlease restart the application.", "Unexpected Application Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}