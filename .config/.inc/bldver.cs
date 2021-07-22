using System.Reflection;
using System.Runtime.CompilerServices;

//
// if you want to use a private version file and customize this, see
// file://samsndrop02/CoreXT-Latest/docs/corext/corext/version.htm
//

[assembly: AssemblyVersion("1.0.174.0")]

[assembly: AssemblyCompany("Microsoft Corp.")]
[assembly: AssemblyProduct("Microsoft CoReXT")]
[assembly: AssemblyCopyright("2006")]

#if ENABLE_CODESIGN

#if ENABLE_PRS_DELAYSIGN
[assembly: AssemblyKeyFile(@"")]
[assembly: AssemblyKeyName("")]
[assembly: AssemblyDelaySign(true)]
#else
[assembly: AssemblyKeyFile(@"")]
[assembly: AssemblyKeyName("")]
[assembly: AssemblyDelaySign(false)]
#endif

#endif
