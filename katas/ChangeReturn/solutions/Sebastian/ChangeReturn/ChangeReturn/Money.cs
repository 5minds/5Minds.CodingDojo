namespace ChangeReturn
{
    public class Money
    {
        public enum MoneyType
        {
            EuroBill,
            EuroCoin,
            CentCoin
        };

        public static class EuroBills
        {
            // must always be in descending order, otherwise change calculations will be incorrect
            public static decimal[] ExistingBills = { 100, 50, 20, 10, 5 };
        }

        public static class EuroCoins
        {
            // must always be in descending order, otherwise change calculations will be incorrect
            //public static decimal[] ExistingCoins = { 2m, 1m };
            public static decimal[] ExistingCoins = { };
        }

        public static class CentCoins
        {
            // must always be in descending order, otherwise change calculations will be incorrect
            public static decimal[] ExistingCoins = { 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };
        }

        public decimal NumericalValue { get; private set; }

        public MoneyType Type { get; private set; }

        public override string ToString()
        {
            var typeName = string.Empty;
            switch (Type)
            {
                case MoneyType.EuroBill:
                    typeName = "Euro bill";
                    break;

                case MoneyType.EuroCoin:
                    typeName = "Euro coin";
                    break;

                case MoneyType.CentCoin:
                    typeName = "Cent coin";
                    break;
            }

            int value = (int)(Type == MoneyType.CentCoin ? NumericalValue * 100 : NumericalValue);
            var result = string.Format("{0} {1}", value, typeName);

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Money compare && compare.NumericalValue == NumericalValue && compare.Type == Type)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(NumericalValue, Type);
        }

        public static bool operator ==(Money lhs, Money rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Money lhs, Money rhs) => !(lhs == rhs);

        public Money(decimal numericalValue, MoneyType moneyType)
        {
            NumericalValue = numericalValue;
            Type = moneyType;
        }

    }
}