using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingList.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    String title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotWorking))]
    bool isWorking;

    public bool IsNotWorking => !IsWorking;
}

