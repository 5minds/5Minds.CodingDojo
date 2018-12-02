namespace BerlinClockWpfApp.ViewModel
{
    using System.Windows.Media;

    public interface IMainViewModel
    {
        #region Public Properties

        SolidColorBrush Hour10Toggle { get; set; }

        SolidColorBrush Hour15Toggle { get; set; }

        SolidColorBrush Hour1Toggle { get; set; }

        SolidColorBrush Hour20Toggle { get; set; }

        SolidColorBrush Hour2Toggle { get; set; }

        SolidColorBrush Hour3Toggle { get; set; }

        SolidColorBrush Hour4Toggle { get; set; }

        SolidColorBrush Hour5Toggle { get; set; }

        SolidColorBrush Minute10Toggle { get; set; }

        SolidColorBrush Minute15Toggle { get; set; }

        SolidColorBrush Minute1Toggle { get; set; }

        SolidColorBrush Minute20Toggle { get; set; }

        SolidColorBrush Minute25Toggle { get; set; }

        SolidColorBrush Minute2Toggle { get; set; }

        SolidColorBrush Minute30Toggle { get; set; }

        SolidColorBrush Minute35Toggle { get; set; }

        SolidColorBrush Minute3Toggle { get; set; }

        SolidColorBrush Minute40Toggle { get; set; }

        SolidColorBrush Minute45Toggle { get; set; }

        SolidColorBrush Minute4Toggle { get; set; }

        SolidColorBrush Minute50Toggle { get; set; }

        SolidColorBrush Minute55Toggle { get; set; }

        SolidColorBrush Minute5Toggle { get; set; }

        SolidColorBrush TickerToggle { get; set; }

        int Timelapse { get; set; }

        #endregion
    }
}