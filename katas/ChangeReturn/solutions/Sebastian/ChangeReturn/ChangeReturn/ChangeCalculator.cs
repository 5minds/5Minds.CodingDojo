using System;
using System.Collections.Generic;
using System.Text;
using static ChangeReturn.Money;

namespace ChangeReturn
{
    public static class ChangeCalculator
    {
        /// <summary>
        /// Takes any positve number an divides it by possible values for bills or coins.
        /// </summary>
        /// <param name="changeAmount">must be a positive value</param>
        /// <returns></returns>
        public static Change ReturnChange(decimal changeAmount)
        {
            if (changeAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(changeAmount));

            var result = new Change();
            var remainingAmount = changeAmount;

            if (changeAmount == 0)
                return result;

            // find the Euro bills that can be ruturned as change
            AddFittingMoneyAmountsToResult(result, ref remainingAmount, EuroBills.ExistingBills, MoneyType.EuroBill);

            // find the Euro coins that can be returned as change
            AddFittingMoneyAmountsToResult(result, ref remainingAmount, EuroCoins.ExistingCoins, MoneyType.EuroCoin);

            // find the Cent coins that can be returned as change
            AddFittingMoneyAmountsToResult(result, ref remainingAmount, CentCoins.ExistingCoins, MoneyType.CentCoin);

            if (remainingAmount != 0)
            {
                throw new InvalidOperationException(
                    "It appears that the amount of change that needs to be returned cannot be divided by the smallest existing amount of money without remainder." +
                    "This means that there is no way for us to return this amount of change with the coins and bills available to us."
                    );
            }

            return result;
        }

        /// <summary>
        /// This function searches for the biggest bills or coins that fit within the remaining amount.
        /// The number of bills or coins is then added to the result and the remaining amount is reduced by their value.
        /// </summary>
        public static void AddFittingMoneyAmountsToResult(Change result, ref decimal remainingAmount, decimal[] existingAmounts, MoneyType moneyType)
        {
            for (int i = 0; i < existingAmounts.Length; i++)
            {
                var amount = existingAmounts[i];
                if (amount <= 0)
                    throw new ArgumentOutOfRangeException(nameof(existingAmounts));

                var division = remainingAmount / amount;
                int times = (int)division;

                // if the remaining amount can be dived by the value of this bill or coin
                if (times >= 1)
                {
                    // that means we can return this bill or coin as change
                    result.ChangeMoney.Add((new Money(amount, moneyType), times));

                    // and reduce the remaining amount to give
                    remainingAmount -= (amount * times);
                }
            }
        }

    }
}
