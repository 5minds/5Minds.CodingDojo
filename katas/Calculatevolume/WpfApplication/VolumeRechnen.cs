using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Autor: Rajesh Murali */


namespace WpfApplication
{
    class VolumeRechnen
    {

        private const double CubicFeet2CubicMeter = 0.0283168;
        private const double CubicFeet2Barrel = 0.237476809;

        private List<long> tops;
        private ParameterRechnen pmr;

        public VolumeRechnen(List<long> tops, ref ParameterRechnen rechnParam)
        {
            this.tops = tops;
            this.pmr = rechnParam;
        }

        public double ReVolume()
        {
            double vol = 0.0;
            double sum = 0.0;
            double bot = 0.0;
            
            

            foreach (long top in tops)
            {
                bot = top + pmr.BASEDELTA;
                sum += top >= pmr.FLUIDCONTACT ? 0.0 : bot > pmr.FLUIDCONTACT ? pmr.FLUIDCONTACT - top : bot - top;
            }

            switch (pmr.UNIT)
            {
                case VolumeUnit.CubicFeet:
                    vol = pmr.CELLAREA * sum;
                    break;
                case VolumeUnit.CubicMeter:
                    vol = pmr.CELLAREA * sum * CubicFeet2CubicMeter;
                    break;
                case VolumeUnit.Barrel:
                    vol = pmr.CELLAREA * sum * CubicFeet2Barrel;
                    break;
                default:
                    break;
            }

            return vol;
        }
    }
}
