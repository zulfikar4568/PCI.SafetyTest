using PCI.SafetyTest.Config;
using Quartz;
using System;
using System.Collections.Generic;

namespace PCI.SafetyTest
{

    public class Scheduler
    {
        private readonly IScheduler _scheduler;
        public Dictionary<string, dynamic> jobData = new Dictionary<string, dynamic>();
        public Scheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void StartCronJob()
        {
            // Start the CronJob
            ScheduleJob();

            _scheduler.Start().ConfigureAwait(true).GetAwaiter().GetResult();
        }
        public void StopCronJob(object sender, EventArgs e)
        {
            _scheduler.Shutdown().ConfigureAwait(true).GetAwaiter().GetResult();
        }

        private void ScheduleJob()
        {
            // Put the data form if exists!
            SchedulerCronJob<Job.CheckConnectionJob>(AppSettings.CheckConnectionCronExpression ?? "0/10 * * ? * * *", jobData.ContainsKey(typeof(Job.CheckConnectionJob).Name) ? jobData[typeof(Job.CheckConnectionJob).Name] : null);
        }

        private void SchedulerCronJob<T>(string cronExpression, dynamic data = null) where T : IJob
        {
            var jobName = typeof(T).Name;

            var job = JobBuilder
                .Create<T>()
                .WithIdentity(jobName, $"{jobName}-Group")
                .Build();

            // Put the data form if exists!
            if (data != null) job.JobDataMap.Put(data.GetType().Name, data);

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobName}-Trigger", $"{jobName}-TriggerGroup")
                .StartNow()
                .WithCronSchedule(cronExpression)
                .Build();

            _scheduler.ScheduleJob(job, trigger).ConfigureAwait(true).GetAwaiter().GetResult();
        }
    }
}
