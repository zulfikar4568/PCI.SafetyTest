using Quartz;
using System;
using System.Threading.Tasks;

namespace PCI.SafetyTest.Job
{
    public class CheckConnectionJob : IJob
    {
        private readonly UseCase.CheckConnection _usecase;
        public CheckConnectionJob(UseCase.CheckConnection usecase)
        {
            _usecase = usecase ?? throw new ArgumentNullException(nameof(usecase));
        }
        async Task IJob.Execute(IJobExecutionContext context)
        {
            #if DEBUG
                await Console.Out.WriteLineAsync($"Check Connection Job Called!");
            #endif
            await _usecase.CheckTheConnection(context.MergedJobDataMap);
        }
    }
}
