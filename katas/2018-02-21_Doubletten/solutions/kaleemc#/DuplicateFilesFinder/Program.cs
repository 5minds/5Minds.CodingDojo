using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFilesFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            IDublettenprüfung _dublettenprüfung = new Dublettenprüfung();
            var duplicateBysize =_dublettenprüfung.Sammle_Kandidaten("D:\\vehicleimage");            
            var duplicateByHash = _dublettenprüfung.Prüfe_Kandidaten(duplicateBysize);           
        }
    }
}
