using ChangeReturnKata.BusinessObject;

namespace ChangeReturnKata.Calculator
{
    public class ChangeReturnCalculator
    {
        public decimal Costs { get; }
        public decimal Paid { get; }
        public decimal ChangeReturn { get; }

        public ChangeReturnCalculator(decimal costs, decimal paid)
        {
            Costs = costs;
            Paid = paid;
            ChangeReturn = paid - costs;
        }

        public Change GetChangeReturn()
        {
            var change = new Change(ChangeReturn);
            return change;
        }
    }
}
