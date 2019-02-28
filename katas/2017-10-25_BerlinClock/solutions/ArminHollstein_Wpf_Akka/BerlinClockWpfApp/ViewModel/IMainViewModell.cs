using BerlinClockWpfApp.ViewModel.Rows;

namespace BerlinClockWpfApp.ViewModel
{
    public interface IMainViewModel
    {
        #region Public Properties

        int Timelapse { get; set; }
        
         SecondsRow SecondsRow { get;  }
         HoursInIncrementsOfFiveRow Hours5Row { get; }
         HoursInIncrementsOfOneRow Hours1Row { get;  }
         MinutesInIncrementsOfFiveRow Minutes5Row { get; }
         MinutesInIncrementsOfOneRow Minutes1Row { get; }

        #endregion
    }
}