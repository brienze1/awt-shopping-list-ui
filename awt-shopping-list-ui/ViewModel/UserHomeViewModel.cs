using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace ShoppingList.ViewModel;

public partial class UserHomeViewModel : BaseViewModel
{
    public UserHomeViewModel()
    {
        Title = "Home";
    }

    public ObservableCollection<Model.ShoppingList> ShoppingLists { get; } = new();

    [RelayCommand]
    async Task CreateShoppingListAsync()
    {
        ShoppingLists.Add(new Model.ShoppingList("test"));
    }
}

