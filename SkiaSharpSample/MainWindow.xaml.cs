using System.Threading;
using Microsoft.UI.Xaml;

namespace SkiaSharpSample
{
	public sealed partial class MainWindow : Window
	{
		static int windowCounter = 1;

		public MainWindow()
		{
			InitializeComponent();

			Title = $"Window Number {windowCounter++}";
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
