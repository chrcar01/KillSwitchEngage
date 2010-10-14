using System;

namespace KillSwitchEngage.UI.Infrastructure
{
	public class DocumentAddRequestedEventArgs : EventArgs
	{
		public string Controller { get; private set; }
		public string Action { get; private set; }		
		public DocumentAddRequestedEventArgs(string controller, string action)
		{
			Controller = controller;
			Action = action;
		}
	}
}
