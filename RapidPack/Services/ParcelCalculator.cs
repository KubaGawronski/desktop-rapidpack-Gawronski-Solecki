namespace RapidPack.Services;

public class ParcelCalculator
{
    const int cenaBazowa = 10;
    const int cenaZaKilogram = 2;
    const int maxWaga = 30;

    public int CalculatePrice(int waga, int wysokosc, int szerokosc, int glebokosc, bool ekspres, int typ)
    {
        int cena = cenaBazowa + (waga*cenaZaKilogram);
        int sumaWymiarow = wysokosc + szerokosc + glebokosc;

        if (sumaWymiarow > 150)
        {
            cena = (int)(cena * 1.5); 
        }
        if (typ == 1)
        {
            cena += 10;
        }
        if (typ == 2)
        {
            cena = 100;
        }
        if (ekspres)
        {
            cena += 15;
        }
        return cena;
    }
}