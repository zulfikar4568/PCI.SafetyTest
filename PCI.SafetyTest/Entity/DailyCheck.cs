using CsvHelper.Configuration;
using PCI.SafetyTest.Config;

namespace PCI.SafetyTest.Entity
{
    public class DailyCheck : Base { }

    public sealed class DailyCheckMap : ClassMap<DailyCheck>
    {
        public DailyCheckMap()
        {
            Map(m => m.Step ).Index(AppSettings.StepDC);
            Map(m => m.Value ).Index(AppSettings.ValueDC);
        }
    }
}
