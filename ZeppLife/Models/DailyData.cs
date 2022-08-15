using System;
using System.Collections.Generic;
using System.Text;

namespace ZeppLife
{
    public class DailyData
    {
        public DailyData(int steps, int rank, string status)
        {
            Steps = steps;
            Rank = rank;
            Status = status;
        }

        public int Steps { get; set; }
        public int Rank { get; set; }
        public string Status { get; set; }
    }
}
