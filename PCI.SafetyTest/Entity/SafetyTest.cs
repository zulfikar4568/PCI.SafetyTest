using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using PCI.SafetyTest.Config;

namespace PCI.SafetyTest.Entity
{
    public class SafetyTest : Base { }

    public sealed class SafetyTestMap : ClassMap<SafetyTest>
    {
        public SafetyTestMap()
        {
            Map(m => m.Step).Index(AppSettings.StepST);
            Map(m => m.Value).Index(AppSettings.Value);
        }
    }
}
