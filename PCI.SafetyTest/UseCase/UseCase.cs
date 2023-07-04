using Autofac;
using PCI.SafetyTest.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCI.SafetyTest.UseCase
{
    class UseCase : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<SafetyTest>().As<ISafetyTest>();
            moduleBuilder.RegisterType<DailyCheck>().As<IDailyCheck>();
            moduleBuilder.RegisterType<CheckConnection>().AsSelf();
        }
    }
}
