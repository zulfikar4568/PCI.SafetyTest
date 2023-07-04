using Autofac;
using Autofac.Extras.Quartz;
using PCI.SafetyTest.Config;
using PCI.SafetyTest.Util;
using Quartz.Logging;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Sockets;
using System.Reflection;

namespace PCI.SafetyTest
{
    public static class Bootstrapper
    {
        public static ContainerBuilder DependencyInjectionBuilder(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new Driver.Driver());
            containerBuilder.RegisterModule(new Repository.Repository());
            containerBuilder.RegisterModule(new UseCase.UseCase());
            containerBuilder.RegisterModule(new Util.Util());
            containerBuilder.RegisterType<Main>().AsSelf();
            containerBuilder.RegisterType<Scheduler>().AsSelf();
            containerBuilder.RegisterType<ServiceMain>().As<ServiceMain>();
            containerBuilder.RegisterType<BackgroundWorker>().AsSelf();

            // configure and register Quartz
            var schedulerConfig = new NameValueCollection {
                { "quartz.scheduler.instanceName", "MyScheduler" },
                { "quartz.jobStore.type", "Quartz.Simpl.RAMJobStore, Quartz" },
                { "quartz.threadPool.threadCount", "3" }
            };

            // Log for Quartz
            LogProvider.SetCurrentLogProvider(new Job.ConsoleLogProvider());

            containerBuilder.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = ctx => schedulerConfig
            });

            containerBuilder.RegisterModule(new QuartzAutofacJobsModule(typeof(Job.CheckConnectionJob).Assembly));

            return containerBuilder;
        }
        public static bool CheckConnection()
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    if (tcpClient.ConnectAsync(AppSettings.ExCoreHost, Convert.ToInt32(AppSettings.ExCorePort)).Wait(TimeSpan.FromSeconds(3)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    EventLogUtil.LogErrorEvent(AppSettings.AssemblyName == ex.Source ? MethodBase.GetCurrentMethod().Name : MethodBase.GetCurrentMethod().Name + "." + ex.Source, ex);
                    return false;
                }
            }
        }
    }
}
