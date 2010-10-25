using KillSwitchEngage.Data;
using System;
using KillSwitchEngage.Core.Services;

namespace KillSwitchEngage.Core.ViewModels.CompanyManager
{
	public class EditContactViewModel : CoreViewModel
	{
		private ICompanyManagerService _service;
		public EditContactViewModel(ICompanyManagerService service)
		{
			_service = service;
		}

		private Contact _contact;
		public Contact Contact
		{
			get
			{
				return _contact;
			}
			set
			{
				_contact = value;
				RaisePropertyChanged("Contact");
			}
		}

		private Company _company;
		public Company Company
		{
			get
			{
				return _company;
			}
			set
			{
				_company = value;
				RaisePropertyChanged("Company");
			}
		}

		private int _selectedContactType;
		public int SelectedContactType
		{
			get
			{
				return _selectedContactType;
			}
			set
			{
				_selectedContactType = value;
				RaisePropertyChanged("SelectedContactType");
			}
		}
        
	}
}
