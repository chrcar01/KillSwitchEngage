using KillSwitchEngage.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KillSwitchEngage.Core.Services
{
	public interface ICompanyManagerService
	{
		IEnumerable<Company> GetCompanies();
		void SaveCompany(Company company);
		ObservableCollection<State> GetStates();
	}
}
