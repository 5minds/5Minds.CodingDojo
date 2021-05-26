namespace ChangeReturnKata.BusinessObject
{
    public class Change
    {
        public int HundredEuro { get; }
        public int FiftyEuro { get; }
        public int TwentyEuro { get; }
        public int TenEuro { get; }
        public int FiveEuro { get; }

        public int FiftyCent { get; }
        public int TwentyCent { get; }
        public int TenCent { get; }
        public int FiveCent { get; }
        public int TwoCent { get; }
        public int OneCent { get; }

        /// <summary>
        /// Constructor for Change. Calculates the change.
        /// </summary>
        /// <param name="changeReturn">Decimal value.</param>
        public Change(decimal changeReturn)
        {
            HundredEuro = (int) (changeReturn / 100);
            changeReturn %= 100;
            FiftyEuro = (int) (changeReturn / 50);
            changeReturn %= 50;
            TwentyEuro = (int) (changeReturn / 20);
            changeReturn %= 20;
            TenEuro = (int)(changeReturn / 10);
            changeReturn %= 10;
            FiveEuro = (int) (changeReturn / 5);
            changeReturn %= 5;
            FiftyCent = (int) (changeReturn / .50m);
            changeReturn %= .50m;
            TwentyCent = (int) (changeReturn / .20m);
            changeReturn %= .20m;
            TenCent = (int) (changeReturn / .10m);
            changeReturn %= .10m;
            FiveCent = (int) (changeReturn / .05m);
            changeReturn %= .05m;
            TwoCent = (int) (changeReturn / .02m);
            changeReturn %= .02m;
            OneCent = (int) (changeReturn / .01m);
        }
    }
}
