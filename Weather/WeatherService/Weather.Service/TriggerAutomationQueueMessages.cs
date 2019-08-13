using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Weather.Service
{
    public class TriggerAutomationQueueMessages
    {
        private static System.Timers.Timer Timer;
        private int _timeInterval = 0;


        public void StartAutomationService()
        {
            double test = 30 * 1000;
            Timer = new System.Timers.Timer(test);
            Timer.Elapsed += OnTimerElapsed;
            Timer.Enabled = true;
        }


        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Timer.Stop();

                FindAndRunNewAutomationJobs();
                Timer.Interval = (30 * 1000);  // set 8 it from config file
            }
            catch (Exception)
            {
                Timer.Interval = (30 * 1000); //set default in case
            }
            finally
            {
                Timer.Start();
            }
        }

        public void FindAndRunNewAutomationJobs()
        {


            //AutomationWorkEngine objAutomationWorkEngine = new AutomationWorkEngine(context, config);
            try
            {
                // objAutomationWorkEngine.ExecuteRequest(ServiceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //objAutomationWorkEngine = null;
            }
        }
    }
}
