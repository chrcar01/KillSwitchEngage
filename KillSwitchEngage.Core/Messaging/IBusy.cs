using System;

namespace KillSwitchEngage.Core.Messaging
{
	public interface IBusy
	{
		bool IsBusy { get; set; }
	}
}
