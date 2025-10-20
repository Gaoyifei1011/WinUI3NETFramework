using Microsoft.UI.Xaml;

namespace WinUI3NETFramework
{
    public partial class App : Application
    {
        public Window MainWindow { get; private set; }

        public App()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动应用程序时调用，初始化应用主窗口
        /// </summary>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);

            MainWindow = new MainWindow();
            MainWindow.Activate();
        }
    }
}
