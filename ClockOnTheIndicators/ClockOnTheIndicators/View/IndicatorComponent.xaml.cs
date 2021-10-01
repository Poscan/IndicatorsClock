using Xamarin.Forms;

namespace ClockOnTheIndicators.View
{
    public partial class IndicatorComponent : ContentView
    {
        public static readonly BindableProperty TimeAtomItemProperty =
            BindableProperty.Create(nameof(TimeAtomItem), typeof(int), typeof(IndicatorComponent), 0,
                BindingMode.TwoWay, propertyChanged: PropertyChangingEventHandler);

        private int _timeAtomItem;
        public int TimeAtomItem
        {
            set
            {
                _timeAtomItem = value;
                OnPropertyChanged();
            }
            get => _timeAtomItem;
        }

        private static void PropertyChangingEventHandler(BindableObject bindable, object value, object newValue)
        {
            ((IndicatorComponent) bindable).Update(int.Parse(newValue.ToString()));
        }

        public IndicatorComponent()
        {
            InitializeComponent();
        }

        public void Update(int value)
        {
            if (_timeAtomItem == value) return;

            for (int i = 0, j = value; i < Indicator.Children.Count; i++, j /= 2)
            {
                Indicator.Children[i].BackgroundColor = j % 2 != 0 ? Color.Aqua : Color.DarkSlateGray;
            }

            TimeAtomItem = value;
        }
    }
}