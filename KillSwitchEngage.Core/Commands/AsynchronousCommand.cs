using System;
using System.Windows.Input;
using System.ComponentModel;
using KillSwitchEngage.Core.Messaging;

namespace KillSwitchEngage.Core.Commands
{
	public class AsynchronousCommand : ICommand
	{
		private BackgroundWorker _worker;
		private IBusy _busyObject;
		private Func<bool> _canExecute;
		public AsynchronousCommand(IBusy target, Action activity)
			: this(target, activity, null)
		{
		}
        public AsynchronousCommand(IBusy target, Action activity, Func<bool> canExecute)
		{
			_canExecute = canExecute;
			_busyObject = target;
			_worker = new BackgroundWorker();
			_worker.DoWork += (x, y) => activity.Invoke();
			_worker.RunWorkerCompleted += (x, y) => _busyObject.IsBusy = false;
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
			_busyObject.IsBusy = true;
			_worker.RunWorkerAsync(parameter);
		}
	}
}
