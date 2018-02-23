using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Vue2SpaSignalR.Services.Hubs
{
    public class CounterHub : Hub
    {
        
    }

    public class Counter : HostedService
    {
        public Counter(IHubContext<CounterHub> context)
        {
            Clients = context.Clients;
        }

        private IHubClients Clients { get; }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            int counter = 0;

            while (true)
            {
                var counterData = new CounterData
                {
                    Count = counter
                };

                await Clients.All.InvokeAsync("increment", counterData);

                var task = Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

                try
                {
                    await task;
                }
                catch (TaskCanceledException)
                {
                    break;
                }

                counter++;
            }
        }

        public class CounterData
        {
            public int Count { get; set; }
            public String TimeElapsed {
                get
                {
                    return this.timeElapsed();
                }
            }

            String timeElapsed()
            {
                var ts = TimeSpan.FromSeconds(this.Count);
                var sb = new StringBuilder();

                if (ts.Days > 0)
                    sb.AppendFormat("{0} day{1} ", ts.Days, ts.Days > 1 ? "s" : String.Empty);
                if (ts.Hours > 0)
                    sb.AppendFormat("{0} hour{1} ", ts.Hours, ts.Hours > 1 ? "s" : String.Empty);
                if (ts.Minutes > 0)
                    sb.AppendFormat("{0} minute{1} ", ts.Minutes, ts.Minutes > 1 ? "s" : String.Empty);
                if (ts.Seconds > 0)
                    sb.AppendFormat("{0} second{1} ", ts.Seconds, ts.Seconds > 1 ? "s" : String.Empty);

                return sb.ToString();
            }
        }
    }
}
