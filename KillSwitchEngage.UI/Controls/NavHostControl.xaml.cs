using GalaSoft.MvvmLight.Messaging;
using KillSwitchEngage.Core.Navigation;
using Magellan;
using Magellan.Routing;
using Magellan.Transitionals;
using System;
using System.Windows;
using System.Windows.Controls;
using KillSwitchEngage.Core.Messaging;

namespace KillSwitchEngage.Controls
{
	public partial class NavHostControl : UserControl
	{
		#region IsBusyProperty
		public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(NavHostControl));
		public bool IsBusy
		{
			get
			{
				return (bool)GetValue(IsBusyProperty);
			}
			set
			{
				SetValue(IsBusyProperty, value);
			}
		}
		#endregion

		#region MessageToken
		private string _messageToken;
		/// <summary>
		/// Gets the message token used to uniquely identity
		/// any messages sent from anywhere in this control.
		/// </summary>
		/// <value>The message token.</value>
		public string MessageToken
		{
			get
			{
				if (String.IsNullOrEmpty(_messageToken))
				{
					_messageToken = Guid.NewGuid().ToString();
				}
				return _messageToken;
			}
		}
		#endregion

		public NavHostControl()
		{			
			InitializeComponent();
		}
		private INavigator _navigator;
		public NavHostControl(NavigatorFactory navFactory)
		{
			InitializeComponent();
			InitializeNavigator(navFactory);			
		}

		private void RegisterMessageHandlers()
		{

			Messenger.Default.Register<NavigationMessage>(
				this, 
				MessageToken, 
				args => NavigateInternal(args.Controller, args.Action, args.RouteValues, args.Direction)
			);

			Messenger.Default.Register<BusyStatusMessage>(
				this,
				MessageToken,
				args => IsBusy = args.Status
			);

			Messenger.Default.Register<DialogMessage>(
				this,
				MessageToken,
				args =>
				{
					var result = MessageBox.Show(args.Content);
					args.ProcessCallback(result);
				}
			);

			Messenger.Default.Register<ModalMessage>(
				this,
				MessageToken,
				args =>
				{
					//create a new placeholder window
				}
			);
		}

		private void NavigateInternal(string controller, string action, object routeValues, NavigationDirections direction)
		{
			var request = new RouteValueDictionary(routeValues);
			request["MessageToken"] = MessageToken;
			_navigator.NavigateWithTransition(controller, action, direction.ToString(), request);
		}
		public void Navigate(string controller, string action)
		{
			NavigateInternal(controller, action, null, NavigationDirections.Forward);
		}


		public void InitializeNavigator(NavigatorFactory navFactory)
		{
			_navigator = navFactory.CreateNavigator(mainFrame);
			RegisterMessageHandlers();			
		}
	}
}
