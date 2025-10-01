using System;
using System.Threading;
using System.Threading.Tasks;

// Runs whatever modules at 20tps if needed
namespace Content.Server.Core
{
    public static class GlobalTick
    {
        private static bool _running = true;

        public static void Stop() => _running = false;

        public static void Initialize()
        {
            Task.Run(async () =>
            {
                while (_running)
                {
                    await Task.Delay(50);
                    // Run all processes that need to be ran at 20tps here
                }
            });
        }
    }
}
