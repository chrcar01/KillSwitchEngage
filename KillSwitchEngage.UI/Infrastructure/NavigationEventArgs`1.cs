﻿using System;

namespace KillSwitchEngage.UI.Infrastructure
{
	public class NavigationEventArgs<TModel> : NavigationEventArgs
	{
		public TModel Model { get; private set; }		
		public NavigationEventArgs(string controller, string action, TModel model)
			: base(controller, action)
		{
			Model = model;
		}
		public NavigationEventArgs(string controller, string action, TModel model, object routeValues)
			: base(controller, action, routeValues)
		{
			Model = model;
		}
		public NavigationEventArgs(string controller, string action, TModel model, string messageToken)
			: base(controller, action, messageToken)
		{
			Model = model;
		}
		public NavigationEventArgs(string controller, string action, TModel model, object routeValues, string messageToken)
			: base(controller, action, routeValues, messageToken)
		{
			Model = model;
		}
	}

}
