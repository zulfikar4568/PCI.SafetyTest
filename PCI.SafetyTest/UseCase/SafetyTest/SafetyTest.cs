using Camstar.WCF.ObjectStack;
using Camstar.WCF.Services;
using PCI.SafetyTest.Components;
using PCI.SafetyTest.Config;
using PCI.SafetyTest.Entity;
using PCI.SafetyTest.Repository.Opcenter;
using PCI.SafetyTest.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCI.SafetyTest.UseCase
{
    public interface ISafetyTest : Abstraction.IUseCase
    {
        new void MainLogic(string delimiter, string sourceFile, Main mainForm);
    }
    public class SafetyTest : ISafetyTest
    {
        private readonly Repository.ISafetyTest _repository;
        private readonly Util.IProcessFile _processFile;
        private readonly ContainerTransaction _containerTransaction;
        private BackgroundWorker _backgroundWorker;
        private Main _mainForm;
        public SafetyTest(Repository.ISafetyTest repository, Util.IProcessFile processFile, ContainerTransaction containerTransaction, BackgroundWorker backgroundWorker)
        {
            _repository = repository;
            _processFile = processFile;
            _containerTransaction = containerTransaction;
            _backgroundWorker = backgroundWorker;

            // Set Handler for Background Worker
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += DoWork;
            _backgroundWorker.RunWorkerCompleted += RunWorkerComplete;
            _backgroundWorker.ProgressChanged += ProgressChanged;
        }

        public float FilterTheValue(string value)
        {
            string numberMatch = Regex.Match(value, @"\d+\.?\d*").Value;
            float result;
            if (float.TryParse(numberMatch, out result))
            {
                return result;
            } else
            {
                return 0;
            }
        }

        public Dictionary<int, float> GetLogValue(List<Entity.SafetyTest> CompletedData)
        {
            Dictionary<int, float> results = new Dictionary<int, float>();
            if (CompletedData.Count > 0)
            {
                foreach (var data in CompletedData)
                {
                    bool validateKey = int.TryParse(data.Step, out int isKeyOk);
                    bool validateValue = float.TryParse(data.Value, out float isValueOk);
                    if (data.Value != null && data.Value != "" &&  validateKey && validateValue)
                    {
                        results.Add(isKeyOk, isValueOk);
                    }
                }
            }

            // Try logging
            Logging.UpdateMessage(_mainForm, $"Data CSV stored into dictionary got {results.Count}!");

            return results;
        }

        private DataPointDetails[] CombineDataPoint(Dictionary<int, float> LogValue, Dictionary<int, DataPointDetails> ModellingValue)
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

            // Try logging
            Logging.UpdateMessage(_mainForm, $"Combine data got {dataPointDetails.Count} combined and store in dictionary!");

            return dataPointDetails.ToArray();
        }

        public void MainLogic(string delimiter, string sourceFile, Main mainForm)
        {
            if (!_processFile.IsFileExists(sourceFile)) return;
            _mainForm = mainForm;

            if (!_backgroundWorker.IsBusy) _backgroundWorker.RunWorkerAsync(new MainLogic() { Delimiter = delimiter, SourceFile = sourceFile});
        }
        private void RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(1500);
            Logging.UpdateProgressBar(_mainForm, 0);
            Logging.UpdateMessage(_mainForm, "Ready!");
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            BringToFront();

            BackgroundWorker worker = sender as BackgroundWorker;
            // Do some Logic in here!
            var mainLogicData = (MainLogic)e.Argument;
            Logging.UpdateMessage(_mainForm, $"Reading CSV File {mainLogicData.SourceFile}");
            List<Entity.SafetyTest> data = _repository.Reading(mainLogicData.Delimiter, mainLogicData.SourceFile);
            worker.ReportProgress(10);

            var serialNumber = System.IO.Path.GetFileNameWithoutExtension(mainLogicData.SourceFile);
            worker.ReportProgress(20);

            var csvDataInDictionary = GetLogValue(data);
            worker.ReportProgress(45);

            var dataPointDetails = CombineDataPoint(csvDataInDictionary, _repository.GetDataCollectionList());
            worker.ReportProgress(70);

            // Status Field
            EventLogEntryType result = EventLogEntryType.Error;
            string msg;

            if (dataPointDetails.Length > 0)
            {
                Logging.UpdateMessage(_mainForm, $"Doing Transaction for unit {serialNumber}");
                try
                {
                    bool txnResult = _containerTransaction.ExecuteCollectData(serialNumber, AppSettings.UserDataCollectionSafetyTestName, AppSettings.UserDataCollectionSafetyTestRevision, dataPointDetails);
                    if (!txnResult)
                    {
                        Logging.UpdateMessage(_mainForm, $"Retry Collect Data x2 for unit {serialNumber}");
                        txnResult = _containerTransaction.ExecuteCollectData(serialNumber, AppSettings.UserDataCollectionSafetyTestName, AppSettings.UserDataCollectionSafetyTestRevision, dataPointDetails);
                        if (!txnResult)
                        {
                            Logging.UpdateMessage(_mainForm, $"Retry Collect Data x3 for unit {serialNumber}");
                            txnResult = _containerTransaction.ExecuteCollectData(serialNumber, AppSettings.UserDataCollectionSafetyTestName, AppSettings.UserDataCollectionSafetyTestRevision, dataPointDetails);
                            if (!txnResult) MovingFileFailed(System.IO.Path.GetFileName(mainLogicData.SourceFile));
                        }
                    }
                    if (txnResult)
                    {
                        result = EventLogEntryType.Information;
                        msg = $"Success when doing Transaction Collect Data {serialNumber}";
                    } else
                    {
                        result = EventLogEntryType.Error;
                        msg = $"Failed when doing Transaction Collect Data {serialNumber}";
                    }
                }
                catch (Exception ex)
                {
                    ex.Source = AppSettings.AssemblyName == ex.Source ? MethodBase.GetCurrentMethod().Name : MethodBase.GetCurrentMethod().Name + "." + ex.Source;
                    EventLogUtil.LogErrorEvent(ex.Source, ex.Message);
                    result = EventLogEntryType.Error;
                    msg = "Please check event log in event viewer for error!";
                }
                MovingFileSuccess(System.IO.Path.GetFileName(mainLogicData.SourceFile));
            }
            else
            {
                result = EventLogEntryType.Warning;
                msg = $"There's no data Model match for {serialNumber}!";
                MovingFileFailed(System.IO.Path.GetFileName(mainLogicData.SourceFile));
            }

            worker.ReportProgress(100);
            Logging.TransactionLogging(result, _mainForm, msg);
        }

        private void BringToFront()
        {
            _mainForm.Invoke(new MethodInvoker(delegate ()
            {
                _mainForm.Activate();
            }));
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Logging.UpdateProgressBar(_mainForm, e.ProgressPercentage);
        }

        private void MovingFileSuccess(string fileName)
        {
            _processFile.MoveTheFile($"{AppSettings.SourceFolderSafetyTest}\\{fileName}", $"{AppSettings.TargetFolderSafetyTest}\\[{DateTime.Now:MMddyyyyhhmmsstt}]_{fileName}");
        }

        private void MovingFileFailed(string fileName)
        {
            _processFile.MoveTheFile($"{AppSettings.SourceFolderSafetyTest}\\{fileName}", $"{AppSettings.FailedFolderSafetyTest}\\FAILED_[{DateTime.Now:MMddyyyyhhmmsstt}]_{fileName}");
        }
    }
}
