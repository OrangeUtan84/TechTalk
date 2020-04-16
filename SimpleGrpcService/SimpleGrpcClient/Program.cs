using Grpc.Net.Client;
using SimpleGrpcService;
using System;

namespace SimpleGrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
           // var client = new Greeter.GreeterClient(channel);
           // var reply = client.SayHello(
           //     new HelloRequest { Name = "Hans" });

            var timeClient = new TimeProvider.TimeProviderClient(channel);

            using var stream = timeClient.GetTime(new TimeRequest());

            while(stream.ResponseStream.MoveNext(new System.Threading.CancellationToken()).Result)
            {
                Console.Clear();
                Console.WriteLine(stream.ResponseStream.Current.TimeString);
            }

            //Console.WriteLine(reply.Message); ;
        }
    }
}
