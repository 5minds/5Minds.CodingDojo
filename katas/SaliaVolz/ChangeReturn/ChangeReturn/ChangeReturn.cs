using System.Collections.Generic;
using System;

namespace ChangeReturn
{
    public class ChangeReturn
    {
        public static List<decimal> CalculateChange(decimal cost, decimal paid){
            decimal[] ValidChange = {100m, 50m, 20m, 10m, 5m, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };

            decimal changeAmount = paid - cost;

            List<decimal> change = new List<decimal>();
            
            if(changeAmount < 0){
                throw new Exception("Not poid enough!");
            }

            while( changeAmount > 0 ){
                if (changeAmount < ValidChange[ValidChange.Length - 1])
                {
                    throw new Exception("No compatible change");

                }
                foreach (decimal changeSize in ValidChange)
                {

                    if(changeSize <= changeAmount){
                        change.Add(changeSize);
                        changeAmount -= changeSize;
                        break;
                    }
                }
            }
            return change;
        }

    }
}
