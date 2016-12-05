using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ERIMS_Sonic_EmailScheduler
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
                new ERIMS_SonicEmailScheduler() 
            };
            ServiceBase.Run(ServicesToRun);

            //Uncomment below code for debug            
//#if(!DEBUG)
//                            ServiceBase[] ServicesToRun;
//                            ServicesToRun = new ServiceBase[] 
//                            { 
//                                new Erims_ACI_ImportEvent() 
//                            };
//                            ServiceBase.Run(ServicesToRun);
//#else
//            ERIMS_SonicEmailScheduler obj = new ERIMS_SonicEmailScheduler();
//            obj.niktest();
//#endif
        }
    }
}
