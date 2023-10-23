using System.Diagnostics;

namespace HangfireApp.BackgroundJobs
{
    public class ContinuationsJobs
    {
        public static void AfterJobs(string id)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine("o jobdan sonra çalıştı"));
        }
    }
}
