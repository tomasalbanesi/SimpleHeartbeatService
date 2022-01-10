using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHeartBeatService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Heartbeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new Heartbeat());
                    s.WhenStarted(hearbeat => hearbeat.Start());
                    s.WhenStopped(hearbeat => hearbeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("HearbeatService");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("This is a sample heartbeat service using Topshelf in C#.NET");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
