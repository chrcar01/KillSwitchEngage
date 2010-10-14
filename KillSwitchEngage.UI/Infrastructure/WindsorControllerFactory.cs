using Castle.Windsor;
using Magellan.Framework;
using Magellan.Routing;
using System;

namespace KillSwitchEngage.UI.Infrastructure
{

	public class WindsorControllerFactory : IControllerFactory
	{
		private IWindsorContainer _container;
		internal WindsorControllerFactory(IWindsorContainer container)
		{
			_container = container;
		}
		public ControllerFactoryResult CreateController(ResolvedNavigationRequest request, string controllerName)
		{
			var controller = _container.Resolve<IController>(controllerName);
			return new ControllerFactoryResult(controller, null);
		}
	}
}
