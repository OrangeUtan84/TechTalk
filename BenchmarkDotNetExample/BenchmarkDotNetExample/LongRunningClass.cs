using System;
using System.Threading;

namespace BenchmarkDotNetExample
{
    public class LongRunningClass
    {
        public void TrackIn(string itemId)
        {
            var someVal = new Random().Next(500, 2000);
            Thread.Sleep(someVal);
        }

        public Item GetItem(string itemId)
        {
            var someVal = new Random().Next(400, 1200);
            Thread.Sleep(someVal);
            return new Item
            {
                ItemId = itemId,
                ItemState = new Random().Next(0, 2) == 0 ? false : true,
                ProductionOrder = "12345678"
            };
        }

        public void TrackOut(string itemId)
        {
            var someVal = new Random().Next(500, 3000);
            if(someVal % 7 == 0)
            {
                someVal = 7000;
            }
            Thread.Sleep(someVal);
        }
    }
}
