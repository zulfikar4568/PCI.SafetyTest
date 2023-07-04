using PCI.SafetyTest.Config;
using PCI.SafetyTest.Util;
using System.IO;

namespace PCI.SafetyTest.Driver.FileWatcherInstance
{
    public class DailyCheckFileWatcherInstance : BaseFileWatcherInstance
    {
        public DailyCheckFileWatcherInstance(string path, IProcessFile processFile)
        {
            processFile.CheckAndCreateDirectory(path);
            Instance = new FileSystemWatcher(path);
        }
        public override string patternFile()
        {
            return AppSettings.DailyCheckFileName is null || AppSettings.DailyCheckFileName == "" ? "*.csv" : AppSettings.DailyCheckFileName;
        }
    }
}
