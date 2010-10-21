using Castle.MicroKernel.Registration;
using Castle.Windsor;
using KillSwitchEngage.Core.ViewModels;
using KillSwitchEngage.Data;
using KillSwitchEngage.Data.Repositories;
using KillSwitchEngage.UI.Infrastructure;
using Magellan;
using Magellan.Framework;
using Magellan.Transitionals;
using Magellan.Transitionals.Transitions;
using System;
using System.Linq;
using System.Windows;

namespace KillSwitchEngage.UI
{
	public partial class App : Application
	{
		private static readonly IWindsorContainer _container;
		static App()
		{
			_container = new WindsorContainer();
		}
		
		protected override void OnStartup(StartupEventArgs e)
		{
			NavigationTransitions.Table.Add("Backward", "Forward", () => new SlideTransition(SlideDirection.Back));
			NavigationTransitions.Table.Add("Forward", "Backward", () => new SlideTransition(SlideDirection.Forward));

			
			RegisterTypes(_container);
			//Make sure all types registered before the next line.
			TypeResolver.Initialize(_container);


			var controllers = new WindsorControllerFactory(_container);

			var routes = new Magellan.ControllerRouteCatalog(controllers);
			routes.MapRoute("{controller}/{action}");

			var navFactory = new NavigatorFactory(routes);
			var mainWindow = new MainWindow(navFactory);
			mainWindow.Show();
			base.OnStartup(e);
		}

		private void RegisterTypes(IWindsorContainer _container)
		{
			RegisterControllers(_container);
			RegisterServices(_container);
			var exportedTypes = typeof(CoreViewModel).Assembly.GetExportedTypes();
			_container.Register(
				AllTypes.FromAssemblyContaining<CoreViewModel>()
					.Where(Component.IsInSameNamespaceAs<CoreViewModel>(true))
					.Configure(c => c.LifeStyle.Is(Castle.Core.LifestyleType.Transient)));

			_container.Register(
				Component.For<IRepository>()
				.LifeStyle.Transient
				.UsingFactoryMethod(() => { return new GenericRepository(new KillSwitchEntities(), false); }));

			_container.Register(
				Component.For(typeof(KillSwitchEntities))
				.LifeStyle.Transient
				.UsingFactoryMethod(() => { return new KillSwitchEntities(); }));
		}


		private void RegisterServices(IWindsorContainer _container)
		{
			var exportedTypes = typeof(CoreViewModel).Assembly.GetExportedTypes();
			var ifaceTypes = from ifaceType in exportedTypes
							 where ifaceType.FullName.IndexOf("Core.Services") != -1
							 && ifaceType.IsInterface == true
							 select ifaceType;

			foreach (var ifaceType in ifaceTypes)
			{
				string typeName = ifaceType.Namespace + "." + ifaceType.Name.Substring(1);
				var implType = exportedTypes.SingleOrDefault(x => { return x.FullName == typeName; });
				_container.Register(Component.For(ifaceType).ImplementedBy(implType));
			}
		}
		private void RegisterControllers(IWindsorContainer _container)
		{
			var controllerTypes = from controllerType in typeof(App).Assembly.GetExportedTypes()
								  where typeof(IController).IsAssignableFrom(controllerType)
								  select controllerType;
			
			foreach (var controllerType in controllerTypes)
			{
				_container.Register(Component.For<IController>().ImplementedBy(controllerType).Named(controllerType.Name.Replace("Controller", "")));
			}
		}
	}
}