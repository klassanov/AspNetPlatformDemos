using System.Web;

namespace CommonModulesClassLibrary
{
    public class ModulesRegistration
    {
        public static void RegisterAllModules()
        {
            HttpApplication.RegisterModule(typeof(Modules.FirstCommonModule));
            HttpApplication.RegisterModule(typeof(Modules.SecondCommonModule));
            HttpApplication.RegisterModule(typeof(Modules.ThirdCommonModule));
        }
    }
}
