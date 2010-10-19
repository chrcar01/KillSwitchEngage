using System;
using KillSwitchEngage.Core.Navigation;

namespace KillSwitchEngage.UI.Infrastructure
{
    public interface IControllerActionParser
    {
        ControllerActionDescriptor Parse(string controllerDotAction);
    }
}
