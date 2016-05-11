using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace ERIMS_Sonic_ReportScheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[]
            {
                new eRIMS_Sonic_ReportScheduler() 
            };
            ServiceBase.Run(ServicesToRun);


            //Uncomment below code for debug
            //System.ServiceProcess.ServiceBase[] ServicesToRun;
            //ServicesToRun = new System.ServiceProcess.ServiceBase[] { new eRIMS_Sonic_ReportScheduler() };
            //System.ServiceProcess.ServiceBase.Run(ServicesToRun);
            //#else
            //Debug code: this allows the process to run as a non-service.

            //It will kick off the service start point, but never kill it.

            //Shut down the debugger to exit
            //eRIMS_Sonic_ReportScheduler service = new eRIMS_Sonic_ReportScheduler();
            //service.OnStart();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

        }
    }
}