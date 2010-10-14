using KillSwitchEngage.UI.Features.Home.Views;
using KillSwitchEngage.UI.Infrastructure;
using Magellan.Framework;
using System;

namespace KillSwitchEngage.UI.Features.Home
{
	public class HomeController : CoreController
	{
		public ActionResult Index()
		{
			return View(new IndexViewModel());
		}	
		public ActionResult CoolButton()
		{
			return Page();
		}
	}
}
