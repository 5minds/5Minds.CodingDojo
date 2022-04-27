using System;
using System.Collections.Generic;

namespace ClassesChangeReturn
{
    public class CChangeReturn
    {
        public decimal[] arrValidChanges;
        public CChangeReturn(){

            arrValidChanges = new decimal[11]{100, 50, 20, 10, 5, (decimal) 0.5, (decimal) 0.2, (decimal) 0.1, (decimal) 0.05, (decimal) 0.02, (decimal) 0.01};
        }

        public List<decimal> fCalcChangeReturn(decimal p_nTotalCost, decimal p_nTotalPaid){

            List<decimal> listChange = new List<decimal>();
            decimal nDiff = p_nTotalPaid - p_nTotalCost;
            int idxValidChanges = 0;
            // Console.WriteLine("nDiff" + nDiff.ToString());
            // Console.WriteLine("idxValidChanges" + idxValidChanges.ToString());

            while(nDiff > 0){
                
                decimal nCurrentChangeValue = this.arrValidChanges[idxValidChanges];
                if(nDiff >= nCurrentChangeValue || idxValidChanges+1 >= this.arrValidChanges.Length){

                    Console.WriteLine("nDiff" + nDiff.ToString());
                    Console.WriteLine("nCurrentChangeValue" + nCurrentChangeValue.ToString());
                    nDiff -= nCurrentChangeValue;
                    listChange.Add(nCurrentChangeValue);
                } else {
                    
                    idxValidChanges++;
                }
            }
            return listChange;
        }
    }
}