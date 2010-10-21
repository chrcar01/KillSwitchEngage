using KillSwitchEngage.Core.Messaging;
using Magellan.Framework;
using System;

namespace KillSwitchEngage.UI.Infrastructure
{
	public class CoreController : Controller
	{

		private void TrySetMessageToken(ISupportMessageTokens model)
		{
			if (model != null && Request.RouteValues.ContainsKey("MessageToken"))
				model.SetMessageToken(Request.RouteValues["MessageToken"].ToString());
		}
		protected virtual PageResult View(ISupportMessageTokens model)
		{
			TrySetMessageToken(model);
			return Page(model);
		}
		protected virtual PageResult View(string viewName, ISupportMessageTokens model)
		{
			TrySetMessageToken(model);
			return Page(viewName, model);
		}
	}
}
