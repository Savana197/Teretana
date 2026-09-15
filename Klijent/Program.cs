namespace Klijent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Komunikacija.Instance.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ne mogu da se povežem na server: " + ex.Message);
                return;
            }
            Application.Run(new MainForm());
        }
    }
}