using Autofac;

namespace PCI.SafetyTest.Util
{
    class Util : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<ProcessFile>().As<IProcessFile>();
        }
    }
}
