using System;

namespace KillSwitchEngage.Core.Messaging
{
	/// <summary>
	/// Component that supports MessageTokens.
	/// </summary>
	public interface ISupportMessageTokens
	{
		string MessageToken { get; }
		void SetMessageToken(string messageToken);
	}
}
