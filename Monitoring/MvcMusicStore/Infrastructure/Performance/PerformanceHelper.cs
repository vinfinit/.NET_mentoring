using System.Diagnostics;
using Monitoring;

namespace MvcMusicStore.Infrastructure.Performance
{
    public static class PerformanceHelper
    {
        public static void IncrementCounter(string counterName)
        {
            using (var counter = new PerformanceCounter(LogCounterConstants.CategoryName, counterName, false))
            {
                counter.Increment();
            }
        }
    }
}