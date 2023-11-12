using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingList.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    public string title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotWorking))]
    public bool isWorking;

    public bool IsNotWorking => !IsWorking;
}

