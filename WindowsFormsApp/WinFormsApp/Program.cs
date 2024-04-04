namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            MainForm mainForm = new MainForm();
            mainForm.Show();
            Application.Run();
        }
    }
}