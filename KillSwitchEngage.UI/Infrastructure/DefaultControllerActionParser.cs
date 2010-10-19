using System;
using KillSwitchEngage.Core.Navigation;

namespace KillSwitchEngage.UI.Infrastructure
{
    public class DefaultControllerActionParser : IControllerActionParser
    {
        public ControllerActionDescriptor Parse(string controllerDotAction)
        {
            #region contract
            if (String.IsNullOrEmpty(controllerDotAction))
                throw new ArgumentException("controllerDotAction is null or empty.", "controllerDotAction");
            if (controllerDotAction.Split('.').Length != 2)
                throw new ArgumentException("controllerDotAction should contain the name of the controller and the name of the action separated by a period.  For example, Home.Index, which indicates the HomeController and the action Index on the HomeController");
            #endregion

            return new ControllerActionDescriptor(controllerDotAction.Split('.')[0], controllerDotAction.Split('.')[1]);
        }
    }
}
