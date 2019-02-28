using System.Windows.Media;
using Akka.Actor;

namespace BerlinClockWpfApp.ViewModel.Rows
{
    public class MinuteBase    
    {
        protected readonly SolidColorBrush _minuteOffColor =
            new BrushConverter().ConvertFromString("#33EE8D03") as SolidColorBrush;

        protected readonly SolidColorBrush _minuteOnColor =
            new BrushConverter().ConvertFromString("#FFEE8D03") as SolidColorBrush;

        protected readonly SolidColorBrush _quarterOffColor =
            new BrushConverter().ConvertFromString("#33EE0303") as SolidColorBrush;

        protected readonly SolidColorBrush _quarterOnColor =
            new BrushConverter().ConvertFromString("#FFEE0303") as SolidColorBrush;

    }
}