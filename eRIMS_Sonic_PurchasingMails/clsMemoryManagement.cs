using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace StandardModel
{
    // <summary>
    // This class is used to run the GC.Collect and set the working set size for this process
    // This display the accurate report of memory usage in Task Manager
    //  http://addressof.com/blog/archive/2003/11/19/281.aspx
    // </summary>
    // <remarks></remarks>
    class clsMemoryManagement
    {
        // Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" ( _
        //ByVal process As IntPtr, _
        //ByVal minimumWorkingSetSize As Integer, _
        //ByVal maximumWorkingSetSize As Integer) As Integer

        //Public Shared Sub FlushMemory()
        //    GC.Collect()
        //    GC.WaitForPendingFinalizers()
        //    If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
        //        SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
        //    End If
        //End Sub

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if ((Environment.OSVersion.Platform == PlatformID.Win32NT))
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
    }
}
