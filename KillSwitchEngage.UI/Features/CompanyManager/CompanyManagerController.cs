using KillSwitchEngage.Core.ViewModels.CompanyManager;
using KillSwitchEngage.Data;
using KillSwitchEngage.UI.Infrastructure;
using Magellan.Framework;
using System;

namespace KillSwitchEngage.UI.Features.CompanyManager
{
	public class CompanyManagerController : CoreController
	{
		public ActionResult ListCompanies()
		{
			return View(TypeResolver.Get<ListCompaniesViewModel>());
		}

		public ActionResult EditCompany(Company company)
		{
			var model = TypeResolver.Get<EditCompanyViewModel>();
			model.Company = company;
			return View(model);
		}

		public ActionResult CreateCompany()
		{
			return View("EditCompany", TypeResolver.Get<EditCompanyViewModel>());
		}
	}
}
