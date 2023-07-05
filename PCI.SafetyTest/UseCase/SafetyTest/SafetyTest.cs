using PCI.SafetyTest.Config;
using PCI.SafetyTest.Entity;
using PCI.SafetyTest.Repository.Opcenter;
using PCI.SafetyTest.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
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
        private DataMapper<Entity.SafetyTest> _dataMapper;
        public SafetyTest(Repository.ISafetyTest repository, Util.IProcessFile processFile, ContainerTransaction containerTransaction, BackgroundWorker backgroundWorker, DataMapper<Entity.SafetyTest> dataMapper)
        {
            _repository = repository;
            _processFile = processFile;
            _containerTransaction = containerTransaction;
            _backgroundWorker = backgroundWorker;
            _dataMapper = dataMapper;

            // Set Handler for Background Worker
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += DoWork;
            _backgroundWorker.RunWorkerCompleted += RunWorkerComplete;
            _backgroundWorker.ProgressChanged += ProgressChanged;
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

            var csvDataInDictionary = _dataMapper.GetLogValue(data);
            worker.ReportProgress(45);
            Logging.UpdateMessage(_mainForm, $"Data CSV stored into dictionary got {csvDataInDictionary.Count}!");

            var dataPointDetails = _dataMapper.CombineDataPoint(csvDataInDictionary, _repository.GetDataCollectionList());
            worker.ReportProgress(70);
            Logging.UpdateMessage(_mainForm, $"Combine data got {dataPointDetails.Length} combined and store in dictionary!");
            
            // Status Field
            string msg;
            EventLogEntryType result;
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
                        }
                    }
                    if (txnResult)
                    {
                        result = EventLogEntryType.Information;
                        msg = $"Success when doing Transaction Collect Data {serialNumber}";
                    }
                    else
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
            }
            else
            {
                result = EventLogEntryType.Warning;
                msg = $"There's no data Model match for {serialNumber}!";
            }

            if (result == EventLogEntryType.Error || result == EventLogEntryType.Warning)
            {
                MovingFileFailed(System.IO.Path.GetFileName(mainLogicData.SourceFile));
            } else
            {
                MovingFileSuccess(System.IO.Path.GetFileName(mainLogicData.SourceFile));
            }

            worker.ReportProgress(100);
            Logging.TransactionLogging(result, _mainForm, msg);
        }

        private void BringToFront()
        {
            _mainForm.Invoke(new MethodInvoker(delegate ()
            {
                _mainForm.TopMost = true;
                _mainForm.Focus();
                _mainForm.BringToFront();
                _mainForm.TopMost = false;
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
