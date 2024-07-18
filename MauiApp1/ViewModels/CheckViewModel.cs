using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels;

public partial class CheckViewModel : ObservableObject {
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Total))]
    [NotifyPropertyChangedFor(nameof(Tip))]
    [NotifyPropertyChangedFor(nameof(PersonalAmount))]
    double _amount;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Total))]
    [NotifyPropertyChangedFor(nameof(Tip))]
    [NotifyPropertyChangedFor(nameof(PersonalAmount))]
    double _tipRate;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PersonalAmount))]
    int _numPeople = 1;

    public double Tip => CheckViewModel.RoundUp(Amount * (TipRate / 100.0));
    public double Total => CheckViewModel.RoundUp(Amount + Tip);
    public double PersonalAmount => CheckViewModel.RoundUp(Total / (NumPeople * 1.0));

    private static double RoundUp(double amount) {
        decimal n = 0;

        try
        {
            n = (decimal)amount;
            n = System.Math.Ceiling(n * 100) / 100;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex);
        }

        return (double)n;
    }
}