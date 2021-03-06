﻿using Magellan;
using System;
using System.Windows;
using KillSwitchEngage.UI.Infrastructure;
using KillSwitchEngage.Controls;
using AvalonDock;
using GalaSoft.MvvmLight.Messaging;
using KillSwitchEngage.Core.Messaging;
using KillSwitchEngage.UI.Windows;

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
            Model = new MainWindowViewModel(new ReflectionBasedControllerActionVerifier(), new DefaultControllerActionParser());

            Messenger.Default.Register<AddDocumentMessage>(
                this,
                args =>
                {
                    AddDocument(args.Content.Controller, args.Content.Action);
                }
            );

			Messenger.Default.Register<ModalMessage>(
				this,
				args =>
				{
					var win = new NavHostWindow(_navFactory);
					win.Navigate(args.Controller, args.Action);
					win.Owner = this;
					win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
					win.ShowDialog();
				}
			);
		}

		private void AddDocument(string controller, string action)
		{
			var navHost = new NavHostControl(_navFactory);			
			var doc = new DocumentContent();
			doc.Title = "Document" + Model.MyDocuments.Count;
			doc.Content = navHost;
			Model.MyDocuments.Add(doc);

			// bring the newly added document's tab into focus.
			docPane.SelectedIndex = Model.MyDocuments.Count - 1;
            navHost.Navigate(controller, action);
		}

	}
}
