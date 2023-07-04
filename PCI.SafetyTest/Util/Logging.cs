using PCI.SafetyTest.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCI.SafetyTest.Util
{
    public class Logging
    {
        internal static string LoggingContainer(string Container, string TxnId, string Message = "")
        {
            return $"Container: {Container}, LogId: {TxnId}, Message: {Message}";
        }
        internal static string LoggingResource(string Resource, string TxnId, string Message = "")
        {
            return $"Resource: {Resource}, LogId: {TxnId}, Message: {Message}";
        }
        public static void UpdateProgressBar(Main mainForm, int value)
        {
            mainForm.Invoke(new MethodInvoker(delegate () {
                mainForm.SetProgressBar(value);
            }));
        }

        public static void UpdateMessage(Main mainForm, string message, System.Diagnostics.EventLogEntryType diagnostic = System.Diagnostics.EventLogEntryType.Information)
        {
            mainForm.Invoke(new MethodInvoker(delegate () {
                mainForm.SetLabelMessage(message);
                EventLogUtil.LogEvent(message, diagnostic, 3);
            }));
        }

        public static void TransactionLogging(EventLogEntryType status, Main mainForm, string message)
        {
            switch (status)
            {
                case EventLogEntryType.Information:
                    UpdateMessage(mainForm, message);
                    ZIAlertBox.Success("Transaction Success!", message);
                    break;
                case EventLogEntryType.Warning:
                    UpdateMessage(mainForm, message, EventLogEntryType.Warning);
                    ZIAlertBox.Success("Transaction Cancelled!", message);
                    break;
                case EventLogEntryType.Error:
                    UpdateMessage(mainForm, message, EventLogEntryType.Error);
                    ZIAlertBox.Success("Transaction Failed!", message);
                    break;
                default:
                    break;
            }
        }
    }
}
