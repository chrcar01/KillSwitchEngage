using AvalonDock;
using System;

namespace KillSwitchEngage.UI.Infrastructure
{
	public class DocumentAddedEventArgs : EventArgs
	{
		public DocumentContent Document { get; private set; }		
		public DocumentAddedEventArgs(DocumentContent document)
		{
			Document = document;
		}
	}
}
