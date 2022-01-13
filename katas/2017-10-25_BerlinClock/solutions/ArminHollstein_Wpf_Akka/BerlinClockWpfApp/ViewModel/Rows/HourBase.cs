using System.Windows.Media;
using Akka.Actor;

namespace BerlinClockWpfApp.ViewModel.Rows
{
    public class HourBase    
    {
        protected readonly SolidColorBrush _hourOffColor =
            new BrushConverter().ConvertFromString("#33F50303") as SolidColorBrush;

        protected readonly SolidColorBrush _hourOnColor =
            new BrushConverter().ConvertFromString("#FFF50303") as SolidColorBrush;
    }
}