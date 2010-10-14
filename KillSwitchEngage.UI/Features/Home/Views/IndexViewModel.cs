using KillSwitchEngage.UI.Infrastructure;
using System;
using System.Threading;
using System.Windows.Input;

namespace KillSwitchEngage.UI.Features.Home.Views
{
	public class IndexViewModel : CoreViewModel
	{
		public ICommand RunLongProcessCommand
		{
			get
			{
				return AsyncCommand(() => Thread.Sleep(15*1000));
			}
		}
		public ICommand ShowDialogCommand
		{
			get
			{
				return DialogCommand("Hello World");
			}
		}
	}
}
