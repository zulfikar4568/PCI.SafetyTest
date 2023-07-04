using Camstar.WCF.ObjectStack;
using Camstar.WCF.Services;
using PCI.SafetyTest.Config;
using PCI.SafetyTest.Util;
using System;
using System.Reflection;

namespace PCI.SafetyTest.Driver.Opcenter
{
    public class ResourceTransaction
    {
        private readonly Helper _helper;
        public ResourceTransaction(Helper helper)
        {
            _helper = helper;
        }

        public bool CollectResourceDataTxn(CollectResourceData ServiceObject, CollectResourceDataService Service, bool IgnoreException = true)
        {
            string TxnId = Guid.NewGuid().ToString();
            try
            {
                string sMessage = "";
                CollectResourceData oServiceObject = null;
                ResultStatus oResultStatus = null;
                EventLogUtil.LogEvent(Logging.LoggingResource(ServiceObject.Resource.Name, TxnId, "Setting input data for Collect Data ..."), System.Diagnostics.EventLogEntryType.Information, 2);
                oServiceObject = ServiceObject;

                EventLogUtil.LogEvent(Logging.LoggingResource(ServiceObject.Resource.Name, TxnId, "Execution Collect Data ...."), System.Diagnostics.EventLogEntryType.Information, 2);
                oResultStatus = Service.ExecuteTransaction(oServiceObject);
                bool statusMoveStd = _helper.ProcessResult(oResultStatus, ref sMessage, false);
                EventLogUtil.LogEvent(Logging.LoggingResource(ServiceObject.Resource.Name, TxnId, sMessage), System.Diagnostics.EventLogEntryType.Information, 2);
                return statusMoveStd;
            }
            catch (Exception ex)
            {
                ex.Source = AppSettings.AssemblyName == ex.Source ? MethodBase.GetCurrentMethod().Name : MethodBase.GetCurrentMethod().Name + "." + ex.Source;
                EventLogUtil.LogErrorEvent(Logging.LoggingResource(ServiceObject.Resource.Name, TxnId, ex.Source), ex);
                if (!IgnoreException) throw ex;
                return false;
            }
            finally
            {
                if (!(Service is null)) Service.Close();
            }
        }
    }
}
