using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNetExample;
using System;

namespace BenchmarkTestApp
{
   //[SimpleJob(launchCount:3, warmupCount:10,targetCount:30)]
   [SimpleJob(BenchmarkDotNet.Engines.RunStrategy.ColdStart, targetCount:5)]
    [RPlotExporter]
    public class Program
    {
        private LongRunningClass _longRunningClass = new LongRunningClass();

        [Benchmark]
        public void DoMoveIn()
        {
            _longRunningClass.TrackIn("123");
        }

        [Benchmark]
        public void DoMoveOut()
        {
            _longRunningClass.TrackOut("123");
        }
        
        [Benchmark]
        public void GetItem()
        {
             _longRunningClass.GetItem("123");
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();

        }
    }
}
