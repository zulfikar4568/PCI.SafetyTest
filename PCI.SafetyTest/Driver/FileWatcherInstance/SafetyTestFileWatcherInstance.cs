using PCI.SafetyTest.Util;
using System.IO;

namespace PCI.SafetyTest.Driver.FileWatcherInstance
{ 
    public class SafetyTestFileWatcherInstance : BaseFileWatcherInstance
    {
        public SafetyTestFileWatcherInstance(string path, IProcessFile processFile)
        {
            processFile.CheckAndCreateDirectory(path);
            Instance = new FileSystemWatcher(path);
        }
        public override string patternFile()
        {
            return "*.csv";
        }
    }
}
