using KillSwitchEngage.Core.Messaging;
using Magellan.Framework;
using System;

namespace KillSwitchEngage.UI.Infrastructure
{
	public class CoreController : Controller
	{
		protected virtual PageResult View(ISupportMessageTokens model)
		{
			if (model != null && Request.RouteValues.ContainsKey("MessageToken"))
				model.SetMessageToken(Request.RouteValues["MessageToken"].ToString());
			return Page(model);
		}
	}
}
