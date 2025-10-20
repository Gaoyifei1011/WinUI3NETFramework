using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Threading;

namespace WinUI3NETFramework
{
    /// <summary>
    /// PowerToolbox 桌面程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Start((param) =>
            {
                SynchronizationContext.SetSynchronizationContext(new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread()));
                new App();
            });
        }
    }

    public class DispatcherQueueSynchronizationContext : SynchronizationContext
    {
        private readonly DispatcherQueue m_dispatcherQueue;

        public DispatcherQueueSynchronizationContext(DispatcherQueue dispatcherQueue)
        {
            m_dispatcherQueue = dispatcherQueue;
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));

            m_dispatcherQueue.TryEnqueue(() => d(state));
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException("Send not supported");
        }

        public override SynchronizationContext CreateCopy()
        {
            return new DispatcherQueueSynchronizationContext(m_dispatcherQueue);
        }
    }
}
