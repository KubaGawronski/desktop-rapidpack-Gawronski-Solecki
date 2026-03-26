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
   
}