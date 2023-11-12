using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingList.Service;
using ShoppingList.View;

namespace ShoppingList.ViewModel;

public partial class UserHomeViewModel : BaseViewModel
{

    private ShoppingListService shoppingListService;
    public ObservableCollection<Model.ShoppingList> ShoppingLists { get; set; } = new();

    [ObservableProperty]
    public Model.ShoppingList selectedShoppingList;

    public UserHomeViewModel(ShoppingListService shoppingListService)
    {
        Title = "Home";
        this.shoppingListService = shoppingListService;
    }

    public async Task OnNavigatedTo()
    {
        var shoppingLists = await shoppingListService.GetShoppingListsAsync();
        ShoppingLists.Clear();
        foreach (var shoppingList in shoppingLists)
        {
            ShoppingLists.Add(shoppingList);
        }

        SelectedShoppingList = null;
    }

    [RelayCommand]
    async Task CreateShoppingListAsync()
    {
        if (IsWorking)
        {
            return;
        }

        try
        {
            IsWorking = true;

            await Shell.Current.GoToAsync($"{nameof(ManageShoppingListPage)}", true);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task EditShoppingListAsync()
    {
        if (IsWorking || SelectedShoppingList == null)
        {
            return;
        }

        try
        {
            IsWorking = true;

            await Shell.Current.GoToAsync($"{nameof(ManageShoppingListPage)}", true,
                new Dictionary<string, object>
                {
                    {"SelectedShoppingList", SelectedShoppingList}
                });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task DeleteShoppingListAsync()
    {
        if (IsWorking)
        {
            return;
        }

        try
        {
            IsWorking = true;

            await this.shoppingListService.DeleteShoppingList(SelectedShoppingList.Id);

            ShoppingLists.Remove(SelectedShoppingList);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task LogOutAsync()
    {
        if (IsWorking)
        {
            return;
        }

        try
        {
            IsWorking = true;

            await Shell.Current.GoToAsync("..", true);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

}

