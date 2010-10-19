using System;

namespace KillSwitchEngage.Core.Navigation
{
	public class NavigationEventArgs : EventArgs
	{
		public string Controller { get; private set; }
		public string Action { get; private set; }
		public object RouteValues { get; private set; }
		public string MessageToken { get; private set; }
		public NavigationDirections Direction { get; private set; }

		public NavigationEventArgs(string controller, string action)
			: this(controller, action, NavigationDirections.Forward)
		{
		}
        public NavigationEventArgs(string controller, string action, NavigationDirections direction)
			: this(controller, action, null, String.Empty, direction)
		{
		}
		public NavigationEventArgs(string controller, string action, string messageToken)
			: this(controller, action, messageToken, NavigationDirections.Forward)
		{
		}
        public NavigationEventArgs(string controller, string action, string messageToken, NavigationDirections direction)
			: this(controller, action, null, messageToken, direction)
		{
		}
		public NavigationEventArgs(string controller, string action, object routeValues)
			: this(controller, action, routeValues, NavigationDirections.Forward)
		{
		}
        public NavigationEventArgs(string controller, string action, object routeValues, NavigationDirections direction)
			: this(controller, action, routeValues, String.Empty, direction)
		{
		}
		public NavigationEventArgs(string controller, string action, object routeValues, string messageToken)
			: this(controller, action, routeValues, messageToken, NavigationDirections.Forward)
		{
		}
        public NavigationEventArgs(string controller, string action, object routeValues, string messageToken, NavigationDirections direction)
		{
			Controller = controller;
			Action = action;
			RouteValues = routeValues;
			MessageToken = messageToken;
			Direction = direction;
		}
	}
}
