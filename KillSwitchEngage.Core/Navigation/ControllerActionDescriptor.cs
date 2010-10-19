using System;

namespace KillSwitchEngage.Core.Navigation
{
    public class ControllerActionDescriptor
    {
        public string Controller { get; private set; }
        public string Action { get; private set; }        
        public ControllerActionDescriptor(string controller, string action)
        {
            Controller = controller;
            Action = action;
        }
    }
}
