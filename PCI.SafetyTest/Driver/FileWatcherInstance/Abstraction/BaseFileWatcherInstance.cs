using System.IO;

namespace PCI.SafetyTest.Driver.FileWatcherInstance
{
    public abstract class BaseFileWatcherInstance
    {
        public FileSystemWatcher Instance;
        public abstract string patternFile();
    }
}
