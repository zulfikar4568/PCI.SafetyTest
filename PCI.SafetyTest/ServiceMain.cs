using PCI.SafetyTest.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCI.SafetyTest
{
    public class ServiceMain
    {
        private readonly Driver.IFileWatcher<UseCase.ISafetyTest, Driver.FileWatcherInstance.SafetyTestFileWatcherInstance> _watcherSafetyTest;
        private readonly Driver.IFileWatcher<UseCase.IDailyCheck, Driver.FileWatcherInstance.DailyCheckFileWatcherInstance> _watcherDailyCheck;
        public ServiceMain(Driver.IFileWatcher<UseCase.ISafetyTest, Driver.FileWatcherInstance.SafetyTestFileWatcherInstance> watcherSafetyTest, Driver.IFileWatcher<UseCase.IDailyCheck, Driver.FileWatcherInstance.DailyCheckFileWatcherInstance> watcherDailyCheck)
        {
            _watcherSafetyTest = watcherSafetyTest;
            _watcherDailyCheck = watcherDailyCheck;
        }

        public void Start(Main mainForm)
        {
            _watcherSafetyTest.Init(mainForm);
            _watcherDailyCheck.Init(mainForm);
        }

        public void Stop(object sender, EventArgs e)
        {
            _watcherSafetyTest.Exit();
            _watcherDailyCheck.Exit();
        }
    }
}
