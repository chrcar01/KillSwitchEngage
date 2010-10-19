using AvalonDock;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KillSwitchEngage.Core.Messaging;
using KillSwitchEngage.Core.ViewModels;
using KillSwitchEngage.UI.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input; 

namespace KillSwitchEngage.UI
{
	public class MainWindowViewModel : CoreViewModel
	{
        private IControllerActionVerifier _verifier;
        private IControllerActionParser _parser;
        
        public MainWindowViewModel(IControllerActionVerifier verifier, IControllerActionParser parser)
        {
            _verifier = verifier;
            _parser = parser;
        }
        private ObservableCollection<DocumentContent> _myDocuments;
		public ObservableCollection<DocumentContent> MyDocuments
		{
			get
			{
				if (_myDocuments == null)
				{
					_myDocuments = new ObservableCollection<DocumentContent>();
				}
				return _myDocuments;
			}
			set
			{
				_myDocuments = value;
				RaisePropertyChanged("MyDocuments");
			}
		}
		private RelayCommand<string> _addDocumentCommand;
		public ICommand AddDocumentCommand
		{
			get
			{
				if (_addDocumentCommand == null)
				{
					_addDocumentCommand = new RelayCommand<string>(
						controllerDotAction => Messenger.Default.Send<AddDocumentMessage>(new AddDocumentMessage(_parser.Parse(controllerDotAction))),
                        controllerDotAction => { return ControllerActionExists(controllerDotAction);  });
				}
				return _addDocumentCommand;
			}
		}
        private bool ControllerActionExists(string controllerDotAction)
        {
            var descriptor = _parser.Parse(controllerDotAction);
            return _verifier.Exists(descriptor.Controller, descriptor.Action);
        }
	}
}
