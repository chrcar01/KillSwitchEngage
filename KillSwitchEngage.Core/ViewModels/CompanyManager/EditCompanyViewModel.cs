using KillSwitchEngage.Core.Services;
using KillSwitchEngage.Data;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KillSwitchEngage.Core.ViewModels.CompanyManager
{
	public class EditCompanyViewModel : CoreViewModel
	{
		private ObservableCollection<CompanyContact> _contacts;
		public ObservableCollection<CompanyContact> Contacts
		{
			get
			{
				if (_contacts == null)
				{
					_contacts = new ObservableCollection<CompanyContact>();
				}
				return _contacts;
			}
			set
			{
				_contacts = value;
				RaisePropertyChanged("Contacts");
			}
		}
		private Company _company;
		public Company Company
		{
			get
			{
				if (_company == null)
				{
					_company = new Company();
				}
				return _company;
			}
			set
			{
				_company = value;
				RaisePropertyChanged("Company");
				Contacts = _service.GetContacts(Company);
			}
		}

		private ObservableCollection<State> _states;
		public ObservableCollection<State> States
		{
			get
			{
				if (_states == null)
				{
					_states = new ObservableCollection<State>();
				}
				return _states;
			}
			set
			{
				_states = value;
				RaisePropertyChanged("States");
			}
		}
		public ICommand CreateContactCommand
		{
			get
			{
				return base.ModalCommand("CompanyManager", "CreateContact");
			}
		}
		public ICommand SaveCompanyCommand
		{
			get
			{
				return base.AsyncCommand(
					() => _service.SaveCompany(this.Company),  //activity
					() => NavigateForwardTo("CompanyManager", "ListCompanies") //onComplete
				);
			}
		}
		
		private ICompanyManagerService _service;
		public EditCompanyViewModel(ICompanyManagerService service)
		{
			_service = service;
			States = _service.GetStates();			
		}
	}
}
