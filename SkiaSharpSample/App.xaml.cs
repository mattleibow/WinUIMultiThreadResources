using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace SkiaSharpSample
{
	public partial class App : Application
	{
		private Window window;

		public App()
		{
			InitializeComponent();
		}

		protected override void OnLaunched(LaunchActivatedEventArgs args)
		{
			if (window != null)
				return;

			Resources.MergedDictionaries.Add(new XamlControlsResources());

			window = new MainWindow();
			window.Activate();
		}
	}
}
