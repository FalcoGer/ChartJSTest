using System;
using System.Collections.Generic;

namespace ChartJSTest
{
    internal class Sensor
    {
        private Dictionary<int, float> minVal;
        private Dictionary<int, float> maxVal;
        private Dictionary<int, float> avgVal;
        private string addr;
        public string Addr { get { return addr; } }
        private string desc;
        public string Desc { get { return desc; } }

        private Random rnd = new Random();

        public Sensor(string addr, string desc)
        {
            this.addr = addr;
            this.desc = desc;
            minVal = new Dictionary<int, float>();
            maxVal = new Dictionary<int, float>();
            avgVal = new Dictionary<int, float>();
            // fill with random garbage
            for (int i = 0; i < 100; i++)
            {
                float[] r = { (float)(rnd.Next(-5000, 5001)/100), (float)(rnd.Next(-5000, 5001) / 100), 0 };
                float min = Math.Min(r[0], r[1]);
                float max = Math.Max(r[0], r[1]);
                float avg = (float)((min + max) / 2);

                minVal.Add(i, min);
                maxVal.Add(i, max);
                avgVal.Add(i, max);
            }
        }
    }
}