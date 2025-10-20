using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using Windows.UI.Popups;

namespace WinUI3NETFramework
{
    /// <summary>
    ///
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // 创建消息对话框并设置内容
            MessageDialog messageDialog = new(string.Format(".NET 版本 {0}", new Version(RuntimeInformation.FrameworkDescription.Remove(0, 15).ToString())));
            (messageDialog as object as IInitializeWithWindow).Initialize((IntPtr)(AppWindow.Id.Value));

            // 添加按钮及其回调
            messageDialog.Commands.Add(new UICommand("关闭", command => { /* 关闭逻辑 */ }));

            // 设置默认按钮和取消按钮
            messageDialog.DefaultCommandIndex = 0;

            // 显示对话框
            await messageDialog.ShowAsync();
        }
    }

    [ComImport]
    [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInitializeWithWindow
    {
        void Initialize(IntPtr hWnd);
    }
}
