using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Win32;

namespace ZeppLife
{
    class DataUtility
    {            
        public static List<TableData> ModifyData(List<Data> MonthData)
        {
            List<String> uniqueUsers = MonthData.Where(p => p.User != null)
                .GroupBy(p => p.User)
                .Select(grp => grp.FirstOrDefault().User).ToList();
            uniqueUsers.Sort();

            List<TableData> tableData = new List<TableData>();
            foreach (var item in uniqueUsers)
            {
                List<Data> userInfoDayContaining = MonthData.Where(m => m.User == item).Select(d => d).ToList();
                List<DailyData> dailyaData = new List<DailyData>(31);
                for (int i = 1; i <= 28; i++)
                {
                    dailyaData.Add(new DailyData ( -1, -1, "no data" )) ;
                }

                foreach (var day in userInfoDayContaining)
                {
                    if (day.Day >= 28)
                        while (dailyaData.Count() < day.Day)
                        {
                            dailyaData.Add(new DailyData(-1, -1, "no data"));
                        }

                    dailyaData[day.Day - 1].Steps = day.Steps;
                    dailyaData[day.Day - 1].Rank = day.Rank;
                    dailyaData[day.Day - 1].Status = day.Status;
                }

                List<int> UserStepsPerMonth = MonthData.Where(m => m.User == item).Select(grp => grp.Steps).ToList();
                tableData.Add(new TableData(
                    item,
                    dailyaData
                    ));
            }
            return tableData;
        }
    }
}

