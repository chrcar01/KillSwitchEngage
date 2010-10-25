using KillSwitchEngage.Core.Navigation;
using System;

namespace KillSwitchEngage.Core.Messaging
{
	public class ModalMessage : NavigationMessage
	{
		public ModalMessage(string controller, string action)
			: base(controller, action)
		{			
		}
	}
}
