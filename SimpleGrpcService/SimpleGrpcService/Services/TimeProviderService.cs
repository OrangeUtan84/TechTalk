using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleGrpcService.Services
{
    public class TimeProviderService : TimeProvider.TimeProviderBase
    {
        public override async Task GetTime(TimeRequest request, IServerStreamWriter<TimeResponse> responseStream, ServerCallContext context)
        {
            while(!context.CancellationToken.IsCancellationRequested)
            {
                // continue streaming
                await responseStream.WriteAsync(new TimeResponse
                {
                    TimeString = DateTime.Now.ToLongTimeString()
                });
                Thread.Sleep(1000);
            }
        }
    }
}
