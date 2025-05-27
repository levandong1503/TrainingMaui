using Serilog.Events;
using Serilog.Formatting;
using System.Diagnostics;
using TrainingMaui.Utils.Constants;
using TrainingMaui.Utils.Helpers;
using TrainingMaui.Utils.Resources;

namespace TrainingMaui.Utils.Encrypted;

public class EncryptedTextFormatter : ITextFormatter
{
    public void Format(LogEvent logEvent, TextWriter output)
    {
        var timestamp = logEvent.Timestamp.ToString(AppResources.DateTimeFormatFullTimeZoneOffset);
        var message = $"{timestamp} [{logEvent.Level}] {GetMessage(logEvent)}";
        message = LogPerformanceMetrics(message);
#if DEBUG
        output.WriteLine(message);
        return;
#endif
        var encryptedMessage = Encrypt(message);
        output.WriteLine(encryptedMessage);
    }

    private string GetMessage(LogEvent logEvent)
    {
        return logEvent.Level == LogEventLevel.Error ? $"{logEvent.RenderMessage()}: {logEvent.Exception?.ToString()} \n{logEvent.Exception?.StackTrace?.ToString()}" : logEvent.RenderMessage();
    }

    private string LogPerformanceMetrics(string message)
    {
        message += "\n\nCurrent processes memory usage:";
        var process = Process.GetCurrentProcess();
        message += $"\nMemory usage: {BytesToMegabytes(process.WorkingSet64)} MB";
        message += $"\nCPU time: {process.TotalProcessorTime}";
        message += $"\nProcess: {process.ProcessName}";
        message += $"\nMaxWorkingSet: {BytesToMegabytes(process.MaxWorkingSet.ToInt64())} MB";
        message += $"\nMinWorkingSet: {BytesToMegabytes(process.MinWorkingSet.ToInt64())} MB";

        // Get total and available memory
        var totalMemory = MemoryManagement.GetTotalMemoryInBytes();
        var availableMemory = MemoryManagement.GetAvailableMemoryInBytes();
        message += $"\nTotal RAM: {BytesToMegabytes((long)totalMemory)} MB";
        message += $"\nAvailable RAM: {BytesToMegabytes((long)availableMemory)} MB";


        return message;
    }

    private string Encrypt(string text)
    {
        var plainTextBytes = EncryptionHelper.AesEncrypt(text, Consts.EncryptKey, Consts.EncryptIV);
        return plainTextBytes;
    }

    private static double BytesToMegabytes(long bytes)
    {
        return (double)bytes / (1024 * 1024);
    }
}
