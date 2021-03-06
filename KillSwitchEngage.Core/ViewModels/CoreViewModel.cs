﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using KillSwitchEngage.Core.Commands;
using KillSwitchEngage.Core.Messaging;
using KillSwitchEngage.Core.Navigation;
using Slf;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace KillSwitchEngage.Core.ViewModels
{
	public abstract class CoreViewModel : ViewModelBase, ISupportMessageTokens, IBusy
	{
		public ICommand AsyncCommand(Action activity)
		{
			return AsyncCommand(activity);
		}
		public ICommand AsyncCommand(Action activity, Action onComplete)
		{
			return new AsynchronousCommand(this, activity, onComplete);
		}
        public ICommand AsyncCommand(Action activity, Func<bool> canExecute)
		{
			return new AsynchronousCommand(this, activity, canExecute);
		}

		public ICommand DialogCommand(string content)
		{
			return new MessageBoxCommand(content, MessageToken);
		}

		public void NavigateForwardTo(string controller, string action)
		{
			Messenger.Default.Send<NavigationMessage>(new NavigationMessage(controller, action), MessageToken);
		}
		public void NavigateBackwardTo(string controller, string action)
		{
			Messenger.Default.Send<NavigationMessage>(new NavigationMessage(controller, action, NavigationDirections.Backward), MessageToken);
		}

		public ICommand CreateNavigateCommand<TData>(string controller, string action, Func<TData, object> routeData)
		{			
			return new RelayCommand<TData>(
				args => Messenger.Default.Send<NavigationMessage>(
					new NavigationMessage(controller, action, routeData(args)), MessageToken)
			);

		}

		public ICommand ModalCommand(string controller, string action)
		{
			return new RelayCommand(
				() => Messenger.Default.Send<ModalMessage>(new ModalMessage(controller, action))
			);
		}

		#region IBusy
		private bool _isBusy;
		public bool IsBusy
		{
			get
			{
				return _isBusy;
			}
			set
			{
				_isBusy = value;
				RaisePropertyChanged("IsBusy");
				Messenger.Default.Send<BusyStatusMessage>(new BusyStatusMessage { Status = value }, MessageToken);
			}
		}
		#endregion

		#region Navigation commands
		private NavigateCommand _navigateBackwardCommand;
		public ICommand NavigateBackwardCommand
		{
			get
			{
				if (_navigateBackwardCommand == null)
				{
					_navigateBackwardCommand = new NavigateCommand(MessageToken, NavigationDirections.Backward);
				}
				return _navigateBackwardCommand;
			}
		}

		private NavigateCommand _navigateForwardCommand;
		public ICommand NavigateForwardCommand
		{
			get
			{
				if (_navigateForwardCommand == null)
				{
					_navigateForwardCommand = new NavigateCommand(MessageToken);
				}
				return _navigateForwardCommand;
			}
		}
		#endregion

		protected virtual ILogger Logger
		{
			get
			{
				return LoggerService.GetLogger("Main");
			}
		}


		#region ISupportMessageTokens implementation
		private string _messageToken;
		public string MessageToken
		{
			get
			{
				if (String.IsNullOrEmpty(_messageToken))
				{
					throw new InvalidOperationException("MessageToken is null.  MessageToken must be set using SetMessageToken");
				}
				return _messageToken;
			}
		}
		public void SetMessageToken(string messageToken)
		{
			if (String.IsNullOrEmpty(messageToken))
				throw new ArgumentException("messageToken is null or empty.", "messageToken");

			_messageToken = messageToken;
		}
		#endregion


	}
}
