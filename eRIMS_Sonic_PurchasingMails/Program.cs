using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace eRIMS_Sonic_PurchasingMails
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new eRIMS_Sonic_PurchasingMails() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
