using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

using OxyPlot;
using OxyPlot.Series;
using System.Linq;

namespace ZeppLife
{
    public class ApplicationUserViewModel : INotifyPropertyChanged
    {
        private TableData selectedUser;
        public IList<DataPoint> Points { get; private set; }
        public IList<DataPoint> MaxPoint { get; private set; }
        public IList<DataPoint> MinPoint { get; private set; }

        public TableData SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                List<DataPoint> pointsTMP = new List<DataPoint>();
                List<DataPoint> pointsMaxTMP = new List<DataPoint>();
                List<DataPoint> pointsMinTMP = new List<DataPoint>();

                var steps = value.DailyDatas.Select(s => s.Steps).ToList();

                for (int i = 0; i < steps.Count;i++)
                {
                    if(steps[i] == value.MaxSteps)
                        pointsMaxTMP.Add(new OxyPlot.DataPoint(i, steps[i]));

                    if (steps[i] == value.MinSteps)
                        pointsMinTMP.Add(new OxyPlot.DataPoint(i, steps[i]));
                        
                    if(steps[i] != -1)
                        pointsTMP.Add(new OxyPlot.DataPoint(i, steps[i]));
                }

                MaxPoint = pointsMaxTMP;
                MinPoint = pointsMinTMP;
                Points = pointsTMP;
                OnPropertyChanged("Points");
                OnPropertyChanged("MaxPoint");
                OnPropertyChanged("MinPoint");
                OnPropertyChanged("SelectedUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
