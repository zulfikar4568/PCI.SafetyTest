using Autofac;
using PCI.SafetyTest.Components;
using System;
using System.Windows.Forms;

namespace PCI.SafetyTest
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check Connection
            bool status = Bootstrapper.CheckConnection();
            if (!status)
            {
                ZIAlertBox.Error("Network Information", "Cannot establish the connection to the server, make sure the IP Server and Port Reachable, the app will close!");
                Environment.Exit(0);
            }
            // Dependency injection
            var containerBuilder = Bootstrapper.DependencyInjectionBuilder(new ContainerBuilder());
            var container = containerBuilder.Build();
            var serviceMain = container.Resolve<ServiceMain>();

            // Setup the MainForm
            var mainForm = container.Resolve<Main>();
            if (status) mainForm.SetNetworkConnected();
            else mainForm.SetNetworkNotConnected();

            var scheduler = container.Resolve<Scheduler>();
            Application.ApplicationExit += new EventHandler(scheduler.StopCronJob);
            Application.ApplicationExit += new EventHandler(serviceMain.Stop);

            // Add data to CheckConnectionJob
            scheduler.jobData.Add(typeof(Job.CheckConnectionJob).Name, mainForm);
            // Start the CronJob
            scheduler.StartCronJob();
            serviceMain.Start(mainForm);

            Application.Run(mainForm);
        }
    }
}
