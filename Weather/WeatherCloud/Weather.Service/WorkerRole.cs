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
            try
            {
                //this.RunAsync(this.cancellationTokenSource.Token).Wait();
                TriggerAutomationQueueMessages objTriggerAutomationQueueMessages = new TriggerAutomationQueueMessages();
                objTriggerAutomationQueueMessages.StartAutomationService();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //this.runCompleteEvent.Set();
            }

            return base.OnStart();
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {

            try
            {
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
