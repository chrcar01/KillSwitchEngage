using KillSwitchEngage.Core.Extensions;
using KillSwitchEngage.Data;
using KillSwitchEngage.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KillSwitchEngage.Core.Services
{
	public class CompanyManagerService : ICompanyManagerService
	{
		private IRepository _repo;
		public CompanyManagerService(IRepository repo)
		{
			_repo = repo;			
		}

		public IEnumerable<Company> GetCompanies()
		{
			return _repo.FindAll<Company>();
		}

		public void SaveCompany(Company company)
		{
			_repo.Save<Company>(company);
		}

		public ObservableCollection<State> GetStates()
		{
			return _repo.FindAll<State>().AsObservableCollection();
		}

		public ObservableCollection<CompanyContact> GetContacts(Company company)
		{
			return _repo.FindAll<CompanyContact>(cc => cc.CompanyID == company.ID).AsObservableCollection();
		}
	}
}
