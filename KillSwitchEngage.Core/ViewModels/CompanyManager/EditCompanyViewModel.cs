using KillSwitchEngage.Data;
using System;
using System.Collections.ObjectModel;
using KillSwitchEngage.Core.Services;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KillSwitchEngage.Core.Navigation;

namespace KillSwitchEngage.Core.ViewModels.CompanyManager
{
	public class EditCompanyViewModel : CoreViewModel
	{
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
