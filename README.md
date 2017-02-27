# BugGuardian 2.0 [BETA]
![](https://dbtek.visualstudio.com/_apis/public/build/definitions/31dcc845-6a11-47d7-90a5-1c340cebf0f1/37/badge)

Easily track you exceptions on VSTS and TFS
------------------------------------------
**BugGuardian** is a library, written in C# and targetting the .Net Standard 1.1, that allows to easily create a Bug or a Task work item on your *Visual Studio Team Services* account or on your on-premises *Team Foundation Server 2015* in the case your application throws an Unhandled Exception.
It can also be invoked manually in try/catch blocks to keep track of handled exceptions.

It supports projects with .Net Framework 4.5 and above. (If you need to target projects that use the .Net Framework 4.0, you have to install the [version 1.3 of the library](https://github.com/n3wt0n/BugGuardian/releases/tag/v1.3.0)).
It supports also UWP apps (Windows 10), .Net Core and Xamarin.

###Installation###

The **BugGuardian** library is available on [NuGet](https://www.nuget.org/packages/DBTek.BugGuardian).
Just search *BugGuardian* in the **Package Manager GUI** or run the following command in the **Package Manager Console**:
```
Install-Package DBTek.BugGuardian
```

**WARNING**: If you are experiencing an error like *"BugGuardian already has a dependency defined for XXX"*, update your NuGet client to the latest version

**WARNING**: Due to a NuGet 3 limitation, web.config and app.config transformation is not supported in this client version and so you have to add the configuration settings manually. See the [Configuration settings page](https://github.com/n3wt0n/BugGuardian/wiki/Configuration-settings).
    
###Usage###

Refer to the [project documentation](https://github.com/n3wt0n/BugGuardian/wiki/Home) to find examples about how to use this library. You can also find some code samples in the **TestApps** folder.


###Support###

If you encounter some issues trying this library, please let me know through the [Issues page](https://github.com/n3wt0n/BugGuardian/issues) and I'll fix the problem as soon as possible!
