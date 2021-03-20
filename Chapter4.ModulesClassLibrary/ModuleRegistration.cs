using System.Web;

namespace Chapter4.ModulesClassLibrary
{
    public class ModuleRegistration
    {
        public static void RegisterAllModules()
        {
            HttpApplication.RegisterModule(typeof(Modules.TestModule));
        }
    }
}
