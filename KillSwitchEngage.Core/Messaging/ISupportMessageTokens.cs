using System;

namespace KillSwitchEngage.Core.Messaging
{
	public interface ISupportMessageTokens
	{
		string MessageToken { get; }
		void SetMessageToken(string messageToken);
	}
}
