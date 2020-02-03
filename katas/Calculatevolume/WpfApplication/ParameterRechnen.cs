using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Autor: Rajesh Murali */

namespace WpfApplication
{
    public struct ParameterRechnen
    {
        private VolumeUnit unit;
        private long CellArea;     
        private double FluidContact; 
        private double BaseDelta;   

        public ParameterRechnen(long ca, double bd, double fc, VolumeUnit un)
        {
            CellArea = ca;
            BaseDelta = bd;
            FluidContact = fc;
            unit = un;
        }

        public long CELLAREA
        {
            get { return CellArea; }
        }

        public double BASEDELTA
        {
            get { return BaseDelta; }
        }

        public double FLUIDCONTACT
        {
            get { return FluidContact; }
        }

        public VolumeUnit UNIT
        {
            get { return unit; }
        }
    }
}
