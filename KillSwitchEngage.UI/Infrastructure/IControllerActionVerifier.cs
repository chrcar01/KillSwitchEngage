using System;

namespace KillSwitchEngage.UI.Infrastructure
{
    public interface IControllerActionVerifier
    {
        bool Exists(string controller, string action);
    }

}
