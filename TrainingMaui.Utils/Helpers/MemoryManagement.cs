using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TrainingMaui.Utils.Helpers;

public class MemoryManagement
{
    [DllImport("kernel32.dll")]
    private static extern bool SetProcessWorkingSetSize(nint process, int minimumWorkingSetSize, int maximumWorkingSetSize);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GlobalMemoryStatusEx(ref MemoryStatusExtended lpBuffer);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct MemoryStatusExtended
    {
        public uint Length;
        public uint MemoryLoad;
        public ulong TotalPhysicalMemory;
        public ulong AvailablePhysicalMemory;
        public ulong TotalPageFile;
        public ulong AvailablePageFile;
        public ulong TotalVirtualMemory;
        public ulong AvailableVirtualMemory;
        public ulong AvailableExtendedVirtualMemory;
    }

    public static void ReduceMemoryUsage()
    {
        // GC.Collect
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Reduce Working Set
        nint processHandle = Process.GetCurrentProcess().Handle;
        SetProcessWorkingSetSize(processHandle, -1, -1);
    }

    public static ulong GetTotalMemoryInBytes()
    {
        var memStatus = new MemoryStatusExtended();
        memStatus.Length = (uint)Marshal.SizeOf(typeof(MemoryStatusExtended));
        return GlobalMemoryStatusEx(ref memStatus) ? memStatus.TotalPhysicalMemory : 0;
    }

    public static ulong GetAvailableMemoryInBytes()
    {
        var memStatus = new MemoryStatusExtended();
        memStatus.Length = (uint)Marshal.SizeOf(typeof(MemoryStatusExtended));
        return GlobalMemoryStatusEx(ref memStatus) ? memStatus.AvailablePhysicalMemory : 0;
    }
}
