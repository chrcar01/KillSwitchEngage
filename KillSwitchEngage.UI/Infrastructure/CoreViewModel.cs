using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Slf;
using System;
using System.Windows.Input;

namespace KillSwitchEngage.UI.Infrastructure
{
	public abstract class CoreViewModel : ViewModelBase, ISupportMessageTokens, IBusy
	{
		public ICommand AsyncCommand(Action activity)
		{
			return AsyncCommand(activity, null);
		}

        public ICommand AsyncCommand(Action activity, Func<bool> canExecute)
		{
			return new AsynchronousCommand(this, activity, canExecute);
		}

		public ICommand DialogCommand(string content)
		{
			return new MessageBoxCommand(content, MessageToken);
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
