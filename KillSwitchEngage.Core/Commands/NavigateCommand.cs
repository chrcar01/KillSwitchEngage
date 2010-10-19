using GalaSoft.MvvmLight.Messaging;
using KillSwitchEngage.Core.Navigation;
using System;
using System.Windows.Input;

namespace KillSwitchEngage.Core.Commands
{
	public class NavigateCommand : ICommand
	{
		private string _messageToken;
		private NavigationDirections _direction;
		
		public NavigateCommand(string messageToken)
			: this(messageToken, NavigationDirections.Forward)
		{
		}

        public NavigateCommand(string messageToken, NavigationDirections direction)
		{
			if (String.IsNullOrEmpty(messageToken))
				throw new ArgumentException("messageToken is null or empty.", "messageToken");

			_messageToken = messageToken;
			_direction = direction;
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}
		public event EventHandler CanExecuteChanged;
		public void RaiseCanExecuteChanged()
		{
			if (CanExecuteChanged == null) return;
			CanExecuteChanged(this, new EventArgs());
		}
		public void Execute(object parameter)
		{
			string controllerDotAction = String.Empty;

			#region contract
			if (parameter == null) throw new ArgumentException("CommandParameter must contain Controller.Action", "parameter");
				controllerDotAction = parameter.ToString();
			
			if (String.IsNullOrEmpty(controllerDotAction))
				throw new ArgumentException("controllerDotAction is null or empty.", "controllerDotAction");
			if (controllerDotAction.Split('.').Length != 2)
				throw new ArgumentException("controllerDotAction should contain the name of the controller and the name of the action separated by a period.  For example, Home.Index, which indicates the HomeController and the action Index on the HomeController");
			#endregion

			string controller = controllerDotAction.Split('.')[0];
			string action = controllerDotAction.Split('.')[1];			
			Messenger.Default.Send<NavigationEventArgs>(new NavigationEventArgs(controller, action, _direction), _messageToken);
		}
	}
}
