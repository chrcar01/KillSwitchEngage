using System;

namespace KillSwitchEngage.UI.Infrastructure
{
	public interface ISupportMessageTokens
	{
		string MessageToken { get; }
		void SetMessageToken(string messageToken);
	}
}
