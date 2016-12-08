using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Erims_ACI_ImportEvent_Mail
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
                    new Erims_ACIImportEvent_Mail() 
                };
            ServiceBase.Run(ServicesToRun);

            //Uncomment below code for debug            
            //#if(!DEBUG)
            //                ServiceBase[] ServicesToRun;
            //                ServicesToRun = new ServiceBase[] 
            //                { 
            //                    new Erims_ACI_ImportEvent() 
            //                };
            //                ServiceBase.Run(ServicesToRun);
            //#else
            //            Erims_ACIImportEvent_Mail obj = new Erims_ACIImportEvent_Mail();
            //            obj.niktest();
            //#endif
        }
    }
}
