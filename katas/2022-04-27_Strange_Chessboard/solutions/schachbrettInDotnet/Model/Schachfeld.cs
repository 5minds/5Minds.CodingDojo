namespace SchachbrettInDotnet.Model
{
    public class Schachfeld
    {

        public Schachfeld(int breite, int hoehe, FeldFarbe farbe)
        {
            this.Breite = breite;
            this.Hoehe = hoehe;
            this.Farbe = farbe;
        }

        public int Breite {get; set;}

        public int Hoehe {get; set;}

        public FeldFarbe Farbe { get; set; }

        public override string ToString()
        {
            return $"Neues Feld - Höhe:{this.Hoehe} - Breite:{this.Breite} - Farbe:{this.Farbe.ToString()}";
        }
    }
}