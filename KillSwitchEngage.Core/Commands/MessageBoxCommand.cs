using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace KillSwitchEngage.Core.Commands
{
	public class MessageBoxCommand : ICommand
	{
		private string _content;
		private Func<bool> _canExecute;
		private DialogMessage _message;
		private string _messageToken;
		public MessageBoxCommand(string content, string messageToken)
		{
			_content = content;
			_message = new DialogMessage(content, null);
			_messageToken = messageToken;
		}
		public bool CanExecute(object parameter)
		{
			return _canExecute != null ? _canExecute() : true;
		}

		public event EventHandler CanExecuteChanged;
		public virtual void RaiseCanExecutedChanged()
		{
			if (CanExecuteChanged == null) return;
			CanExecuteChanged(this, new EventArgs());
		}
		public void Execute(object parameter)
		{
			Messenger.Default.Send<DialogMessage>(_message, _messageToken);
		}
	}
}
