using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magellan.Framework;

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
