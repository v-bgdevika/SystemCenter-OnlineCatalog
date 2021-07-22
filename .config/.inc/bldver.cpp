using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;

//
// if you want to use a private version file and customize this, see
// file://samsndrop02/CoreXT-Latest/docs/corext/corext/version.htm
//

[assembly: AssemblyVersion("1.0.174.0")];

[assembly: AssemblyCompany("Microsoft Corp.")];
[assembly: AssemblyProduct("Microsoft CoReXT")];
[assembly: AssemblyCopyright("2006")];



#if ENABLE_CODESIGN
#if !(BUILD_NO_GLOBAL_STRONG_NAME)
#if ENABLE_PRS_DELAYSIGN
[assembly: AssemblyDelaySign(true)];
[assembly: AssemblyKeyFile("")];
#else
[assembly: AssemblyKeyFile("")];
[assembly: AssemblyKeyName("")];
[assembly: AssemblyDelaySign(false)];
#endif
#endif
#endif
