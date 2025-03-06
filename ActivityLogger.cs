using System;
using System.IO;

public static class ActivityLogger
{
    private static string logFilePath = @"\\D4MDP574\Doc Viewer$\Logs\activity_log.txt";

    public static void Initialize(string customLogFilePath)
    {
        logFilePath = customLogFilePath;
    }

    public static void Log(string activity, string username)
    {
        try
        {
            string logMessage = $"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - {GetLocalIPAddress()} - {username} - {activity}{Environment.NewLine}";
            File.AppendAllText(logFilePath, logMessage);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Erro ao registrar atividade", ex);
        }
    }

    private static string GetLocalIPAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "Local IP Address Not Found!";
    }
}