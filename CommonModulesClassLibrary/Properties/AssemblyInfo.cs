using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using CommonModulesClassLibrary;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("CommonModulesClassLibrary")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CommonModulesClassLibrary")]
[assembly: AssemblyCopyright("Copyright ©  2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("8fece5c1-f32b-4014-8223-b886f49b56b2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]



/*  This attribute calls the specified method of the specified class when the web application that references this 
 *  project starts
 *  The technique can be used for registering modules from the same assembly as the web application as well
 *  RegiterAllModules method of the ModuleRegistration class will be called before Application_Start method
 *  No need to register the module it in the web config
 *  
 *  The sequence in which we define modules is important
 *  Event handlers of modules are called according to the order in which they are registered
 *  
 *  Modules registered in the web.config are called before modules registered with this method
 */
[assembly: PreApplicationStartMethod(typeof(ModulesRegistration), "RegisterAllModules")]
