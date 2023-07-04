using Autofac;

namespace PCI.SafetyTest.UseCase
{
    class UseCase : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<SafetyTest>().As<ISafetyTest>();
            moduleBuilder.RegisterType<DailyCheck>().As<IDailyCheck>();
            moduleBuilder.RegisterType<CheckConnection>().AsSelf();
            moduleBuilder.RegisterType<DataMapper<Entity.SafetyTest>>().AsSelf();
            moduleBuilder.RegisterType<DataMapper<Entity.DailyCheck>>().AsSelf();
        }
    }
}
