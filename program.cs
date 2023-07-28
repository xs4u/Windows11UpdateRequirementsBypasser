using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

class Program
{
    static void Main()
    {
        if (!IsRunningAsAdministrator())
        {
            throw new Exception("This program must be run as administrator.");
        }

        string resourceName = "Windows11UpdateRequirementsBypasser.appraiserres.dll";
        string destinationPath = @"C:\$WINDOWS.~BT\Sources\appraiserres.dll";

        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);

        if (resourceStream != null)
        {
            using FileStream fileStream = new FileStream(destinationPath, FileMode.Create);
            resourceStream.CopyTo(fileStream);

            Console.WriteLine("appraiserres.dll extracted successfully.");
        }
        else
        {
            Console.WriteLine("appraiserres.dll not found in resources.");
        }
        Console.ReadKey(true);
    }

    static bool IsRunningAsAdministrator()
    {
        var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
        var principal = new System.Security.Principal.WindowsPrincipal(identity);
        return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
    }
}
