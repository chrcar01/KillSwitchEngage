using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Magellan;

namespace KillSwitchEngage.UI.Windows
{
	public partial class NavHostWindow : Window
	{
		public NavHostWindow(NavigatorFactory navFactory)
		{
			InitializeComponent();
			navHost.InitializeNavigator(navFactory);
		}
		public void Navigate(string controller, string action)
		{
			navHost.Navigate(controller, action);
		}
	}
}
