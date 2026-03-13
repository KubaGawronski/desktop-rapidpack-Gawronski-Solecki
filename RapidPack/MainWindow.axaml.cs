using Avalonia.Controls;
using RapidPack.Services;

namespace RapidPack;

public partial class MainWindow : Window
{
    private TextBlock _WeightErrorBox;
    private TextBox _Waga;
    private TextBlock _Cena;
    ParcelCalculator _calculator = new ParcelCalculator();
    public MainWindow()
    {
        InitializeComponent();
        _Waga = this.FindControl<TextBox>("WagaTextBox");
        _WeightErrorBox = this.FindControl<TextBlock>("ShowWeightErrorTextBox");
        _Cena = this.FindControl<TextBlock>("PriceTextBox");

        _Waga.KeyUp += (_, _) =>
        {
            if (int.TryParse(_Waga.Text, out int weight) && weight > 30)
            {
                _WeightErrorBox.Text = "Waga paczki nie może przekraczać 30kg!";
                _Cena.Text = "";
            }
            else
            {
              _WeightErrorBox.Text = "";   
              int price = _calculator.CalculatePrice(weight);
              _Cena.Text = $"Cena: {price} zł";
            }
               
        };
    }

}