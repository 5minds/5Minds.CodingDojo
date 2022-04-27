using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangeReturn
{
    public class Change
    {
        /// <summary>
        /// This List holds the change that will be retured, it contains bills or coins and their respective count.
        /// For expampe: 100 Euro Bill times 2, 50 Cent coin times 3, and so on.
        /// </summary>
        public List<(Money Money, int Count)> ChangeMoney { get; private set; }

        public Change()
        {
            ChangeMoney = new List<(Money, int)>();
        }

        public decimal Total
        {
            get
            {
                var total = ChangeMoney.Sum(x => x.Money.NumericalValue * x.Count);

                return total;
            }
        }

        public override string ToString()
        {
            if (ChangeMoney.Count == 0)
                return "no change";

            var builder = new StringBuilder();

            foreach (var item in ChangeMoney)
            {
                builder.AppendFormat("{0}x {1}, ", item.Count, item.Money);
            }

            var result = builder.ToString();
            result = result.TrimEnd(' ', ',');

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Change compare)
            {
                if (ChangeMoney.Count != compare.ChangeMoney.Count)
                    return false;

                for (int i = 0; i < ChangeMoney.Count; i++)
                {
                    if (ChangeMoney[i].Money != compare.ChangeMoney[i].Money ||
                        ChangeMoney[i].Count != compare.ChangeMoney[i].Count)
                        return false;
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(ChangeMoney);
        }

    }
}