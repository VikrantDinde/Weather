using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace Weather.Service
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);


        public override void Run()
        {
            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void RoleEnvironment_Changed(object sender, RoleEnvironmentChangedEventArgs e)
        {
            try
            {
                this.OnStart();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool OnStart()
        {
            TriggerAutomationQueueMessages objTriggerAutomationQueueMessages = new TriggerAutomationQueueMessages();
            objTriggerAutomationQueueMessages.StartAutomationService();

            return base.OnStart();
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {

            try
            {// TODO: Replace the following with your own logic.
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
