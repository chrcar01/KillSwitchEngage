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
		
		protected virtual PageResult View<TModel>() where TModel : ISupportMessageTokens
		{
			var model = TypeResolver.Get<TModel>();
			return View(model);
		}

		protected virtual PageResult View<TModel>(Action<TModel> processModel) where TModel : ISupportMessageTokens
		{
			var model = TypeResolver.Get<TModel>();
			processModel(model);
			return View(model);
		}

		protected virtual PageResult View<TModel>(string viewName) where TModel : ISupportMessageTokens
		{
			var model = TypeResolver.Get<TModel>();
			return View(viewName, model);
		}
	}
}
