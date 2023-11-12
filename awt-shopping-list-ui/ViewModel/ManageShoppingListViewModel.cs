using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingList.Model;
using ShoppingList.Service;

namespace ShoppingList.ViewModel;

[QueryProperty("SelectedShoppingList", "SelectedShoppingList")]
public partial class ManageShoppingListViewModel : BaseViewModel
{
    public ShoppingListService shoppingListService;

    [ObservableProperty]
    public Model.ShoppingList selectedShoppingList;
    public ObservableCollection<Item> Items { get; set; } = new();
    [ObservableProperty]
    public Item selectedItem;

    public ManageShoppingListViewModel(ShoppingListService shoppingListService)
    {
        Title = "Manage shopping list";

        this.shoppingListService = shoppingListService;
    }

    internal void OnNavigatedTo()
    {
        SelectedShoppingList ??= new Model.ShoppingList();

        foreach (var item in SelectedShoppingList.Items)
        {
            Items.Add(item);
        }
    }

    [RelayCommand]
    async Task CreateItemAsync()
    {
        if (IsWorking)
        {
            return;
        }

        try
        {
            IsWorking = true;

            string name = await Shell.Current.DisplayPromptAsync("Create Item", "Item name:");

            Items.Add(new Item(name));
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task EditItemAsync()
    {
        if (IsWorking || SelectedItem == null)
        {
            return;
        }

        try
        {
            IsWorking = true;

            string name = await Shell.Current.DisplayPromptAsync("Edit Item", "Item name:", initialValue: SelectedItem.Name);
            SelectedItem.Name = name;
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task DeleteItemAsync()
    {
        if (IsWorking || SelectedItem == null)
        {
            return;
        }

        try
        {
            IsWorking = true;

            Items.Remove(SelectedItem);

            SelectedItem = null;
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task SaveShoppingListAsync()
    {
        if (IsWorking || SelectedShoppingList.Name == null)
        {
            return;
        }

        try
        {
            IsWorking = true;

            SelectedShoppingList.Items = Items.ToList();
            if (SelectedShoppingList.Id != null)
            {
                await this.shoppingListService.UpdateShoppingListAsync(SelectedShoppingList);
            }
            else
            {
                await this.shoppingListService.CreateShoppingListAsync(SelectedShoppingList);
            }

            await Shell.Current.GoToAsync("..", true);
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
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

            await Shell.Current.GoToAsync("../..");
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task RemoveItemQuantityAsync(Item item)
    {
        if (IsWorking || item.Quantity <= 0)
        {
            return;
        }

        try
        {
            IsWorking = true;

            item.Quantity--;
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task AddItemQuantityAsync(Item item)
    {
        if (IsWorking)
        {
            return;
        }

        try
        {
            IsWorking = true;

            item.Quantity++;
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Unknown error occurred", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }
}

