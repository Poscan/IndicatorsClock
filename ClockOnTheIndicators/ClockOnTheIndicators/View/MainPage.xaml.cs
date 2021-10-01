using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using Xamarin.Forms;

namespace ClockOnTheIndicators.View
{
    public partial class MainPage : ContentPage
    {
        private readonly IList<int> _timeNumberToIndicatorValue =
            new List<int> {63, 6, 91, 79, 102, 109, 125, 7, 127, 111};

        private ObservableCollection<int> _indicatorsTime;

        public MainPage()
        {
            InitializeComponent();

            var t = DateTime.Now;

            IndicatorsTime = new ObservableCollection<int>
            {
                _timeNumberToIndicatorValue[t.Hour / 10],
                _timeNumberToIndicatorValue[t.Hour % 10],
                _timeNumberToIndicatorValue[t.Minute / 10],
                _timeNumberToIndicatorValue[t.Minute % 10],
                _timeNumberToIndicatorValue[t.Second / 10],
                _timeNumberToIndicatorValue[t.Second % 10]
            };
            InitTimer();

            BindingContext = this;
        }

        public void InitTimer()
        {
            var timer = new Timer(1000);
            timer.Elapsed += Update;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Update(object sender, ElapsedEventArgs e)
        {
            var t = DateTime.Now;

            IndicatorsTime = new ObservableCollection<int>
            {
                _timeNumberToIndicatorValue[t.Hour / 10],
                _timeNumberToIndicatorValue[t.Hour % 10],
                _timeNumberToIndicatorValue[t.Minute / 10],
                _timeNumberToIndicatorValue[t.Minute % 10],
                _timeNumberToIndicatorValue[t.Second / 10],
                _timeNumberToIndicatorValue[t.Second % 10]
            };
        }

        public ObservableCollection<int> IndicatorsTime
        {
            get => _indicatorsTime;
            set
            {
                _indicatorsTime = value;
                OnPropertyChanged();
            }
        }
    }
}