using System.Threading;
using Microsoft.UI.Xaml;

namespace SkiaSharpSample
{
	public sealed partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var thread = new Thread(() =>
			{
				Application.Start((p) =>
				{
					var dispatcherQueue = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();
					var syncContext = new Microsoft.UI.Dispatching.DispatcherQueueSynchronizationContext(dispatcherQueue);
					SynchronizationContext.SetSynchronizationContext(syncContext);

					var w = new MainWindow();
					w.Activate();
				});
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
	}
}
