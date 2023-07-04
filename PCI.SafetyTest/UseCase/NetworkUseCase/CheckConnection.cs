using PCI.SafetyTest.Components;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCI.SafetyTest.UseCase
{
    public class CheckConnection
    {
        public async Task CheckTheConnection(JobDataMap dataMap)
        {
            await Task.Run(() =>
            {
                var frmInstance = (Main)dataMap[typeof(Main).Name];
                if (frmInstance == null) return;
                if (frmInstance.IsHandleCreated)
                {
                    bool status = Bootstrapper.CheckConnection();
                    if (!status) frmInstance.Invoke(new Action(delegate () { frmInstance.SetNetworkNotConnected(); }));
                    else frmInstance.Invoke(new Action(delegate () { frmInstance.SetNetworkConnected(); }));
                }
            });          
        }
    }
}
