using Magellan;
using System;
using System.Windows;
using KillSwitchEngage.UI.Infrastructure;
using KillSwitchEngage.Controls;
using AvalonDock;

namespace KillSwitchEngage.UI
{
	public partial class MainWindow : Window
	{
		public MainWindowViewModel Model
		{
			get
			{
				return DataContext as MainWindowViewModel;
			}
			set
			{
				DataContext = value;
			}
		}
		private NavigatorFactory _navFactory;
		public MainWindow(NavigatorFactory navFactory)
		{
			InitializeComponent();
			_navFactory = navFactory;
			Model = new MainWindowViewModel();
			Model.DocumentAddRequested += DocumentAddRequestedHandler;
		}

		void DocumentAddRequestedHandler(object sender, DocumentAddRequestedEventArgs e)
		{
			var navHost = new NavHostControl(_navFactory);			
			var doc = new DocumentContent();
			doc.Title = "Document" + Model.MyDocuments.Count;
			doc.Content = navHost;
			Model.MyDocuments.Add(doc);

			// bring the newly added document's tab into focus.
			docPane.SelectedIndex = Model.MyDocuments.Count - 1;
			navHost.Navigate(e.Controller, e.Action);
		}

	}
}
