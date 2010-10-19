using Magellan.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace KillSwitchEngage.UI.Infrastructure
{
    public class ReflectionBasedControllerActionVerifier : IControllerActionVerifier
    {
        public bool Exists(string controllerName, string actionName)
        {
            var query = from controllerType in Assembly.GetExecutingAssembly().GetExportedTypes()
                        where typeof(IController).IsAssignableFrom(controllerType)
                        && controllerType.Name.ToLower().StartsWith(controllerName.ToLower())
                        select controllerType;

            if (query == null || query.Count() != 1) return false; //Controller not found

            var methods = from method in query.ElementAt(0).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                          where typeof(ActionResult).IsAssignableFrom(method.ReturnType)
                          && method.Name.ToLower() == actionName.ToLower()
                          select method;

            if (methods == null || methods.Count() != 1) return false; //Action not found

            return true;
        }
    }
}
