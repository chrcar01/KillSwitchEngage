using System;
using System.Collections.Generic;
using KillSwitchEngage.Data;
using KillSwitchEngage.Core.Services;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KillSwitchEngage.Core.Navigation;

namespace KillSwitchEngage.Core.ViewModels.CompanyManager
{
	public class ListCompaniesViewModel : CoreViewModel
	{
		private IEnumerable<Company> _companies;
		public IEnumerable<Company> Companies
		{
			get
			{
				if (_companies == null)
				{
					_companies = new List<Company>();
				}
				return _companies;
			}
			set
			{
				_companies = value;
			}
		}
		private RelayCommand<Company> _editCompanyCommand;
		public ICommand EditCompanyCommand
		{
			get
			{
				if (_editCompanyCommand == null)
				{
					_editCompanyCommand = new RelayCommand<Company>(
						c => Messenger.Default.Send<NavigationEventArgs>(
							new NavigationEventArgs("CompanyManager", "EditCompany", new { company = c }), MessageToken)
					);
				}
				return _editCompanyCommand;
			}
		}
		private ICompanyManagerService _service;
		public ListCompaniesViewModel(ICompanyManagerService service)
		{
			_service = service;
			Companies = service.GetCompanies();
		}
	}
}
