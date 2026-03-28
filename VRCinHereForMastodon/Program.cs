namespace VRCinHereForMastodon
{
    internal static class Program
    {
        private static Mutex? AppMutex = null;
        private const string MutexName = "VRCinHereForMastodon_SingleInstance";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 多重起動チェック
            AppMutex = new Mutex(true, MutexName, out bool CreatedNew);
            if (!CreatedNew)
            {
                // 既に起動しているインスタンスが存在する場合
                MessageBox.Show("アプリケーションは既に起動しています。", "VRCinHere for Mastodon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            finally
            {
                // Mutexをリリース
                AppMutex?.ReleaseMutex();
                AppMutex?.Dispose();
            }
        }
    }
}