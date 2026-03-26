using Avalonia.Headless.XUnit;
using RapidPack.Services;
namespace RapidPack.Tests;

public class MainWindowTests
{
   [AvaloniaFact]
   public void CzyWagaWiekszaOd30ZwracaBlad()
   {
      var calculator = new ParcelCalculator();
      
      Assert.Throws<ArgumentException>(() =>
         calculator.CalculatePrice(35, 10, 10, 10, false, 0)
      );
   }
   [AvaloniaFact]
   public void CzyOplataGabarytowaDziala()
   {
      var calculator = new ParcelCalculator();
      
      int price = calculator.CalculatePrice(10, 50, 50, 60, false, 0);
      
      Assert.Equal(45, price);
   }
   
}