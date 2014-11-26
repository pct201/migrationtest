using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace eRIMS_Sonic_PurchasingMailsController
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        static void Main(string[] args)
        {
            // hide the console window                   
            setConsoleWindowVisibility(false, Console.Title);  

            string aMachine = ".";           
            System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController();
            sc.MachineName = aMachine;
            sc.ServiceName = "eRIMS_Sonic_PurchasingMails";
            sc.Start(); 
        }

        public static void setConsoleWindowVisibility(bool visible, string title)
        {
            // below is Brandon's code           
            //Sometimes System.Windows.Forms.Application.ExecutablePath works for the caption depending on the system you are running under.          
            IntPtr hWnd = FindWindow(null, title);

            if (hWnd != IntPtr.Zero)
            {
                if (!visible)
                    //Hide the window                   
                    ShowWindow(hWnd, 0); // 0 = SW_HIDE               
                else
                    //Show window again                   
                    ShowWindow(hWnd, 1); //1 = SW_SHOWNORMA          
            }
        }

    }
}
