using KillSwitchEngage.UI.Features.Home;
using Magellan;
using Magellan.Framework;
using Magellan.Transitionals;
using Magellan.Transitionals.Transitions;
using System;
using System.Windows;

namespace KillSwitchEngage.UI
{
	public partial class App : Application
	{		
		protected override void OnStartup(StartupEventArgs e)
		{
			NavigationTransitions.Table.Add("Backward", "Forward", () => new SlideTransition(SlideDirection.Back));
			NavigationTransitions.Table.Add("Forward", "Backward", () => new SlideTransition(SlideDirection.Forward));

			var controllers = new ControllerFactory();
			controllers.Register("Home", () => { return new HomeController(); });

			var routes = new Magellan.ControllerRouteCatalog(controllers);
			routes.MapRoute("{controller}/{action}");

			var navFactory = new NavigatorFactory(routes);
			var mainWindow = new MainWindow(navFactory);
			mainWindow.Show();
			base.OnStartup(e);
		}
	}
}