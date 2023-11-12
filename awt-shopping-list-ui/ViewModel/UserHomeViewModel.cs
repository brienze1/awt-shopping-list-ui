using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingList.Service;

namespace ShoppingList.ViewModel;

public partial class UserHomeViewModel : BaseViewModel
{

    private ShoppingListService shoppingListService;
    public ObservableCollection<Model.ShoppingList> ShoppingLists { get; set; } = new();

    public UserHomeViewModel(ShoppingListService shoppingListService)
    {
        Title = "Home";
        this.shoppingListService = shoppingListService;
    }

    public async Task OnNavigatedTo()
    {
        var shoppingLists = await shoppingListService.GetShoppingListsAsync();
        foreach (var shoppingList in shoppingLists)
        {
            ShoppingLists.Add(shoppingList);
        }
    }

    [RelayCommand]
    async Task CreateShoppingListAsync()
    {
        ShoppingLists.Add(new Model.ShoppingList("test"));
    }

}

