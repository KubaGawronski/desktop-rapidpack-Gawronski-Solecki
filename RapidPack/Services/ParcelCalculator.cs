namespace RapidPack.Services;

public class ParcelCalculator
{
    const int cenaBazowa = 10;
    const int cenaZaKilogram = 2;
    const int maxWaga = 30;

    int CalculatePrice(int waga)
    {
        if (waga > maxWaga)
        {
            
        }

        int cena = cenaBazowa + (waga*cenaZaKilogram);

        return cena;
    }
}