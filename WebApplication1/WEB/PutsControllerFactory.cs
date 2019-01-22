using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Security;

namespace WebApplication1.WEB
{
    public class PutsControllerFactory : IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            Type controllerType = 
            Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name.EndsWith("Controller") && c.Name.StartsWith(controllerName));
            ConstructorInfo[] construtoresController = controllerType.GetConstructors();
            //Neste caso, não trabalharemos com sobrecarga (os controllers terão apenas um construtor!)
            ConstructorInfo construtorController = construtoresController[0];
            ParameterInfo[] parametrosConstrutor = construtorController.GetParameters();
            if(parametrosConstrutor.Length == 0)
            {
                return construtorController.Invoke(null) as IController;
            }
            Type type = parametrosConstrutor[0].ParameterType;
            if(type == typeof(MvcUser))
            {
                MvcUser user = HttpContext.Current.User as MvcUser;
                return construtorController.Invoke(new object[] { user }) as IController;
            }
            if(type == typeof(ILog))
            {
                ILog log = LogResolver.GetInstance().GetLogReference();
                return construtorController.Invoke(new object[] { log }) as IController;
            }
            return null;
        }

        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            if(controller is IDisposable)
            {
                (controller as IDisposable).Dispose();
            }
        }
    }
}