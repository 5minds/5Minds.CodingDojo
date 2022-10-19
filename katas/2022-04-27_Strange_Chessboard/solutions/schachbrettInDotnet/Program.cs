using SchachbrettInDotnet.Model;
using SchachbrettInDotnet.Service;

var spalteBreiten = args[0].Split(':')[1].Replace('[',' ').Replace(']', ' ').Split(", ");
var zeilenBreiten = args[1].Split(':')[1].Replace('[',' ').Replace(']', ' ').Split(", ");
var farbeNachZeileWechseln = spalteBreiten.GetLength(0) % 2 == 0;
var schachbrett = new Schachbrett();
var farbe = FeldFarbe.Weiß;

foreach (var spaltenBreite in spalteBreiten)
{
    foreach (var zeilenBreite in zeilenBreiten)
    {
        var schachfeld = new Schachfeld(int.Parse(spaltenBreite), int.Parse(zeilenBreite), farbe);
        //Console.WriteLine(schachfeld.ToString());
        schachbrett.Felder.Add(schachfeld);

        farbe = farbe == FeldFarbe.Weiß ? FeldFarbe.Schwarz : FeldFarbe.Weiß; 
    }
    farbe = farbeNachZeileWechseln ? farbe == FeldFarbe.Weiß ? FeldFarbe.Schwarz : FeldFarbe.Weiß : farbe;
}

var schwarzeFelder = FeldGroeßenBerechnungsService.BerechneFelderZuFarbe(schachbrett, FeldFarbe.Schwarz);
var weißeFelder = FeldGroeßenBerechnungsService.BerechneFelderZuFarbe(schachbrett, FeldFarbe.Weiß);
Console.WriteLine($"Summe weiße Flächen {weißeFelder} - Summe schwarze Flächen {schwarzeFelder}");
