﻿using Hangfire;
using System.Diagnostics;

namespace HangfireApp.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(), Cron.Minutely);
           
        }

        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, calisti. Murat");
        }
    }
}
