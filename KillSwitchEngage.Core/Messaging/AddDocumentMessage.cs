using System;
using KillSwitchEngage.Core.Navigation;

namespace KillSwitchEngage.Core.Messaging
{
    public class AddDocumentMessage : GalaSoft.MvvmLight.Messaging.GenericMessage<ControllerActionDescriptor>
    {
        public AddDocumentMessage(ControllerActionDescriptor descriptor)
            : base(descriptor)
        {
        }
    }
}
