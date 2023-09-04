using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;

namespace VendorMachine
{
    public class ReportScheduler
    {
        private readonly Timer timer;
        private readonly ReportDirector reportDirector;

        public ReportScheduler(ReportDirector reportDirector)
        {
            this.reportDirector = reportDirector;
            timer = new Timer();
            timer.Elapsed += TimerElapsed;
        }

        public void ScheduleReportSending()
        {
            DateTime currentTime = DateTime.Now;
            DateTime reportTime = new (currentTime.Year, currentTime.Month, currentTime.Day, 21, 0, 0); // Set report time to 9 o'clock

            if (currentTime > reportTime)
            {
                reportTime = reportTime.AddDays(1); // Schedule the report for the next day if it's already past 9 o'clock
            }
            TimeSpan timeToReport = reportTime - currentTime;
            timer.Interval = timeToReport.TotalMilliseconds;
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            reportDirector.ConstructReport();
            
            Console.WriteLine("Daily report sent");

        }
    }
}
