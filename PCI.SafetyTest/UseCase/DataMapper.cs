using Camstar.WCF.ObjectStack;
using PCI.SafetyTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCI.SafetyTest.UseCase
{
    public class DataMapper<T> where T : Entity.Base
    {
        public string FilterTheValue(string value)
        {
            return Regex.Match(value, @"\d+\.?\d*").Value;
        }

        public Dictionary<int, float> GetLogValue(List<T> CompletedData)
        {
            Dictionary<int, float> results = new Dictionary<int, float>();
            if (CompletedData.Count > 0)
            {
                foreach (var data in CompletedData)
                {
                    bool validateKey = int.TryParse(data.Step, out int isKeyOk);
                    bool validateValue = float.TryParse(FilterTheValue(data.Value), out float isValueOk);
                    if (data.Value != null && data.Value != "" && validateKey && validateValue)
                    {
                        results.Add(isKeyOk, isValueOk);
                    }
                }
            }

            return results;
        }

        public DataPointDetails[] CombineDataPoint(Dictionary<int, float> LogValue, Dictionary<int, DataPointDetails> ModellingValue)
        {
            List<DataPointDetails> dataPointDetails = new List<DataPointDetails>();
            foreach (KeyValuePair<int, DataPointDetails> dataModel in ModellingValue)
            {
                if (LogValue.ContainsKey(dataModel.Key))
                {
                    var dataFill = dataModel.Value;
                    dataFill.DataValue = LogValue[dataModel.Key].ToString();
                    dataPointDetails.Add(dataFill);
                }
            }

            return dataPointDetails.ToArray();
        }
    }
}
