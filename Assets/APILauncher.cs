using System.Diagnostics;
using UnityEngine;

public class ApiRunner
{ 
    private static Process process;
    public static void Run(string args)
    {
        string scriptPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.dataPath, "API", "api.py"));
        ProcessStartInfo psi = new ProcessStartInfo();
        string pythonExePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.dataPath, "venv", "Scripts", "python.exe"));

        psi.FileName = pythonExePath;

        psi.Arguments = $"\"{scriptPath}\" {args}";

        psi.UseShellExecute = false;

        process = new Process
        {
            StartInfo = psi,
            EnableRaisingEvents = true
        };
        process.Start();

    }
}
