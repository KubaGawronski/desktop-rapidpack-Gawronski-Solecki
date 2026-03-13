using Avalonia.Controls;

namespace RapidPack;

public partial class MainWindow : Window
{
    private TextBlock _WeightErrorBox;
    private TextBox _Waga;
    public MainWindow()
    {
        InitializeComponent();
        _Waga = this.FindControl<TextBox>("WagaTextBox");
        _WeightErrorBox = this.FindControl<TextBlock>("ShowWeightErrorTextBox");

        _Waga.KeyUp += (_, _) =>
        {
            if (int.TryParse(_Waga.Text, out int weight) && weight > 30)
                _WeightErrorBox.Text = "Waga paczki nie może przekraczać 30kg!";
            else
                _WeightErrorBox.Text = "";
        };
    }

}