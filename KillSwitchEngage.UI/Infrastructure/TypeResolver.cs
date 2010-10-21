using Castle.Windsor;
using System;

namespace KillSwitchEngage.UI.Infrastructure
{
	public static class TypeResolver
	{
		private static IWindsorContainer _container;
		public static void Initialize(IWindsorContainer container)
		{
			_container = container;
		}
		public static T Get<T>()
		{
			return _container.Resolve<T>();
		}
		public static T Get<T>(string key)
		{
			return _container.Resolve<T>(key);
		}
	}
}
