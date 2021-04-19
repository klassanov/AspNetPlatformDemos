using System.Web;

namespace CommonModulesClassLibrary
{
    public class ModulesRegistration
    {
        public static void RegisterAllModules()
        {
            HttpApplication.RegisterModule(typeof(Modules.ExampleCommonModule));
        }
    }
}
