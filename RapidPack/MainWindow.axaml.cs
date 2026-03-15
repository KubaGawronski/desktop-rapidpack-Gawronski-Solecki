using Avalonia.Controls;
using RapidPack.Services;

namespace RapidPack;

public partial class MainWindow : Window
{
    private TextBlock _WeightErrorBox;
    private TextBox _Waga;
    private TextBlock _Cena;
    private TextBox _Wysokosc;
    private TextBox _Szerokosc;
    private TextBox _Glebokosc;
    private CheckBox _Ekspres;
    private ComboBox _TypPrzesylki;
    private Button _SubmitButton;
    ParcelCalculator _calculator = new ParcelCalculator();
    public MainWindow()
    {
        InitializeComponent();
        _Waga = this.FindControl<TextBox>("WagaTextBox");
        _WeightErrorBox = this.FindControl<TextBlock>("ShowWeightErrorTextBox");
        _Cena = this.FindControl<TextBlock>("PriceTextBox");
        _Wysokosc = this.FindControl<TextBox>("WysokoscTextBox");
        _Szerokosc = this.FindControl<TextBox>("SzerokoscTextBox");
        _Glebokosc = this.FindControl<TextBox>("GlebokoscTextBox");
        _Ekspres = this.FindControl<CheckBox>("WysylkaCheckBox");
        _TypPrzesylki = this.FindControl<ComboBox>("TypPrzesylkiComboBox");
        _SubmitButton = this.FindControl<Button>("SubmitButton");
        _SubmitButton.IsEnabled = false;
        _TypPrzesylki.SelectionChanged += (_, _) => UpdatePrice();
        
        _Waga.KeyUp += (_, _) => UpdatePrice();
        _Wysokosc.KeyUp += (_, _) => UpdatePrice();
        _Szerokosc.KeyUp += (_, _) => UpdatePrice();
        _Glebokosc.KeyUp += (_, _) => UpdatePrice();
        _Ekspres.Click += (_, _) => UpdatePrice();
        void UpdatePrice()
        {
            if (int.TryParse(_Waga.Text, out int weight) &&
                int.TryParse(_Wysokosc.Text, out int h) &&
                int.TryParse(_Szerokosc.Text, out int s) &&
                int.TryParse(_Glebokosc.Text, out int g))
            {
                if (weight > 30)
                {
                    _WeightErrorBox.Text = "Waga paczki nie może przekraczać 30kg!";
                    _Cena.Text = "";
                    _SubmitButton.IsEnabled = false;
                }
                else
                {
                    _WeightErrorBox.Text = "";
                    bool ekspres = _Ekspres.IsChecked == true;
                    int typ = _TypPrzesylki.SelectedIndex;
                    int price = _calculator.CalculatePrice(weight, h, s, g, ekspres, typ);
                    _Cena.Text = $"Cena: {price} zł";
                    _SubmitButton.IsEnabled = true;
                }
            }
            else
            {
                _SubmitButton.IsEnabled = false;
                _Cena.Text = "";
            }
        }
    }
}