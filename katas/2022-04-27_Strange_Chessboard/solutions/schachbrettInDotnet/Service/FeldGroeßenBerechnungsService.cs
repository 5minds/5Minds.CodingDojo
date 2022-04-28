namespace SchachbrettInDotnet.Service
{
    using SchachbrettInDotnet.Model;
    using System.Linq;

    public static class FeldGroeßenBerechnungsService
    {
        public static int BerechneFelderZuFarbe(Schachbrett brett, FeldFarbe farbe)
        {
            var farbFelder = brett.Felder.Where(feld => feld.Farbe == farbe).ToList();
            var summeDerFeldFlaechen = 0;
            farbFelder.ForEach(feld => Flaeche(feld.Hoehe, feld.Breite, ref summeDerFeldFlaechen));
            return summeDerFeldFlaechen;
        }

        private static void Flaeche(int hoehe, int breite, ref int flaeche)
        {
            flaeche += hoehe * breite;
        }
    }
}