using Camstar.WCF.ObjectStack;
using CsvHelper;
using CsvHelper.Configuration;
using PCI.SafetyTest.Config;
using PCI.SafetyTest.Repository.Opcenter;
using PCI.SafetyTest.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PCI.SafetyTest.Repository
{
    public interface IDailyCheck
    {
        List<Entity.DailyCheck> Reading(string delimiter, string sourceFile);
        Dictionary<int, DataPointDetails> GetDataCollectionList();
    }
    public class DailyCheck : IDailyCheck
    {
        private readonly MaintenanceTransaction _maintenanceTransaction;
        public DailyCheck(MaintenanceTransaction maintenanceTransaction)
        {
            _maintenanceTransaction = maintenanceTransaction;
        }
        public List<Entity.DailyCheck> Reading(string delimiter, string sourceFile)
        {
            List<Entity.DailyCheck> result = new List<Entity.DailyCheck>();
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8, // Our file uses UTF-8 encoding.
                Delimiter = delimiter
            };

            configuration.MissingFieldFound = (missingField) =>
            {
                EventLogUtil.LogEvent($"There's missing data field in column index {missingField.Index} {missingField.HeaderNames} was not found! you can ignore.", System.Diagnostics.EventLogEntryType.Warning, 6);
            };

            configuration.BadDataFound = (badData) =>
            {
                EventLogUtil.LogEvent($"Bad data at {badData.RawRecord}, {badData.Field}, {badData.Context}", System.Diagnostics.EventLogEntryType.Warning, 6);
            };

            try
            {

                using (var reader = new StreamReader(sourceFile))
                using (var csv = new CsvReader(reader, configuration))
                {
                    csv.Context.RegisterClassMap<Entity.DailyCheckMap>();
                    var records = csv.GetRecords<Entity.DailyCheck>();
                    result = records.ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Source = AppSettings.AssemblyName == ex.Source ? MethodBase.GetCurrentMethod().Name : MethodBase.GetCurrentMethod().Name + "." + ex.Source;
                EventLogUtil.LogErrorEvent(ex.Source, ex);
            }
            return result;
        }

        public Dictionary<int, DataPointDetails> GetDataCollectionList()
        {
            Dictionary<int, DataPointDetails> results = new Dictionary<int, DataPointDetails>();
            var data = _maintenanceTransaction.GetUserDataCollectionDef(AppSettings.UserDataCollectionDailyCheckName, AppSettings.UserDataCollectionDailyCheckRevision);
            if (data != null)
            {
                foreach (var dataPoint in data.DataPoints)
                {
                    bool validateKey = int.TryParse(dataPoint.Name.ToString().Split('|')[0], out int isKeyOk);
                    if (validateKey)
                    {
                        results.Add(isKeyOk, new DataPointDetails() { DataName = dataPoint.Name.ToString(), DataType = dataPoint.DataType });
                    }
                }
                // Try logging
                EventLogUtil.LogEvent($"User Data Collection Def {AppSettings.UserDataCollectionDailyCheckName} have: {data.DataPoints.Length} data from Opcenter!.\nAnd stored into dictionary: {results.Count} ", System.Diagnostics.EventLogEntryType.Information, 6);
            }
            else
            {
                // Try logging
                EventLogUtil.LogEvent($"There's no data can't be retrieve from opcenter!", System.Diagnostics.EventLogEntryType.Warning, 6);
            }

            return results;
        }
    }
}
