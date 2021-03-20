using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using Chapter4.ModulesClassLibrary;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Chapter4.ModulesClassLibrary")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Chapter4.ModulesClassLibrary")]
[assembly: AssemblyCopyright("Copyright ©  2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e94813b9-3cf6-4fb8-85fc-21881a48b545")]

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



//This attribute calls the specified method when the application starts
//The technique can be used for registering modules from the same assembly as well
//RegiterAllModules method of the ModuleRegistration class will be called before Application_Start method
[assembly: PreApplicationStartMethod(typeof(ModuleRegistration), "RegisterAllModules")]
