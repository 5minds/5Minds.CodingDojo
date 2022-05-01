using System.Linq;
using FindDuplicates.Enums;
using FindDuplicates.Interfaces;

namespace FindDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            IDublettenprüfung _dublettenprüfung = new Dublettenprüfung();

            var findBySize =_dublettenprüfung.Sammle_Kandidaten("C:\\temp");
            if (!findBySize.Any())
            {
                //var foundDuplicatesBySize = _dublettenprüfung.Prüfe_Kandidaten(findBySize);     
            }
            
            var findyByNameAndSize =_dublettenprüfung.Sammle_Kandidaten("C:\\temp", Vergleichsmodi.Größe_und_Name);
            if (!findyByNameAndSize.Any())
            {
                //var foundDuplicatesBySizeAndName = _dublettenprüfung.Prüfe_Kandidaten(findyByNameAndSize);
            }
        }
    }
}
