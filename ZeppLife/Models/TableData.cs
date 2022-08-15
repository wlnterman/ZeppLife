using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeppLife
{
    public class TableData
    {
        public TableData(string user, List<DailyData> dailyDatas)
        {
            User = user;
            DailyDatas = dailyDatas;

        }

        public string User { get; set; }
        public int AverageSteps { get => Convert.ToInt32(DailyDatas.Select(s => s.Steps).Average()); }
        public int MaxSteps { get => DailyDatas.Select(s => s.Steps).Max(); }
        public int MinSteps { get => DailyDatas.Select(s => s.Steps).Where(i => i > -1).Min(); }

        public List<DailyData> DailyDatas { get; set; }
    }
}
