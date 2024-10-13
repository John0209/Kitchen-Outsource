using Microsoft.VisualBasic;
using Serilog;

namespace Kitchen.Application.Utils;

public static class LogUtils
{
    public static void LogWarning(string api, string message, string? error)
    {
        Log.Warning($"API: {api}, Message: {message}, Error: {error}");
    }
}