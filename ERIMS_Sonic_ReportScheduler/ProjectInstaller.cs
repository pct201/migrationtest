using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace ERIMS_Sonic_ReportScheduler
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}