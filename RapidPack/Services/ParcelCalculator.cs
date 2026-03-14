namespace RapidPack.Services;

public class ParcelCalculator
{
    const int cenaBazowa = 10;
    const int cenaZaKilogram = 2;
    const int maxWaga = 30;

    public int CalculatePrice(int waga, int wysokosc, int szerokosc, int glebokosc)
    {
        int cena = cenaBazowa + (waga*cenaZaKilogram);
        int sumaWymiarow = wysokosc + szerokosc + glebokosc;

        if (sumaWymiarow > 150)
        {
            cena = (int)(cena * 1.5); 
        }
        return cena;
    }
}