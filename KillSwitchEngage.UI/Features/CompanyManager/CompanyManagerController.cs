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
			return View<ListCompaniesViewModel>();
		}

		public ActionResult EditCompany(Company company)
		{
			return View<EditCompanyViewModel>(model => model.Company = company);
		}
		
		public ActionResult CreateCompany()
		{
			return View<EditCompanyViewModel>("EditCompany");
		}
		public ActionResult CreateContact()
		{
			return Page();
		}
	}
}
