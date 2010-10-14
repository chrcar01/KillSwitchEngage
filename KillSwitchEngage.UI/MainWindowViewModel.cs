using AvalonDock;
using GalaSoft.MvvmLight.Command;
using KillSwitchEngage.UI.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Reflection;
using mag = Magellan.Framework;

namespace KillSwitchEngage.UI
{
	public class MainWindowViewModel : CoreViewModel
	{

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
						controllerDotAction => RaiseDocumentAddRequested(controllerDotAction),
						controllerDotAction => { return ControllerAndActionExists(controllerDotAction); });

				}
				return _addDocumentCommand;
			}
		}

		private bool ControllerAndActionExists(string controllerDotAction)
		{
			var controllerAndAction = ParseControllerAction(controllerDotAction);
			var controllerName = controllerAndAction.Item1;
			var actionName = controllerAndAction.Item2;

			var query = from controllerType in Assembly.GetExecutingAssembly().GetExportedTypes()
						where typeof(mag.IController).IsAssignableFrom(controllerType)
						&& controllerType.Name.ToLower().StartsWith(controllerName.ToLower())
						select controllerType;

			if (query == null || query.Count() != 1) return false; //Controller not found

			var methods = from method in query.ElementAt(0).GetMethods(BindingFlags.Public | BindingFlags.Instance)
						  where typeof(mag.ActionResult).IsAssignableFrom(method.ReturnType)
						  && method.Name.ToLower() == actionName.ToLower()
						  select method;

			if (methods == null || methods.Count() != 1) return false; //Action not found
			
			return true;
		}

		public event EventHandler<DocumentAddRequestedEventArgs> DocumentAddRequested;
		private void RaiseDocumentAddRequested(string controllerDotAction)
		{
			if (DocumentAddRequested == null) return;
			var controllerAndAction = ParseControllerAction(controllerDotAction);
			DocumentAddRequested(this, new DocumentAddRequestedEventArgs(controllerAndAction.Item1, controllerAndAction.Item2));
		}

		private Tuple<string, string> ParseControllerAction(string controllerDotAction)
		{
			#region contract
			if (String.IsNullOrEmpty(controllerDotAction))
				throw new ArgumentException("controllerDotAction is null or empty.", "controllerDotAction");
			if (controllerDotAction.Split('.').Length != 2)
				throw new ArgumentException("controllerDotAction should contain the name of the controller and the name of the action separated by a period.  For example, Home.Index, which indicates the HomeController and the action Index on the HomeController");
			#endregion

			return new Tuple<string, string>(controllerDotAction.Split('.')[0], controllerDotAction.Split('.')[1]);
		}
	}
}
