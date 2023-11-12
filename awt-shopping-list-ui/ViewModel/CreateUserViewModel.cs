using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingList.Model;
using ShoppingList.Service;
using ShoppingList.View;

namespace ShoppingList.ViewModel;

public partial class CreateUserViewModel : BaseViewModel
{

    private UserService userService;

    public CreateUserViewModel(UserService userService)
    {
        Title = "Create user";
        this.userService = userService;
    }

    [ObservableProperty]
    String username;

    [ObservableProperty]
    String password;

    [ObservableProperty]
    String firstName;

    [ObservableProperty]
    String lastName;

    [RelayCommand]
    async Task CreateUserAsync()
    {
        if (IsWorking)
        {
            return;
        }

        try
        {
            IsWorking = true;

            await userService.CreateUserAsync(new User(Username, Password, FirstName, LastName));

            await Shell.Current.GoToAsync("..", true);
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Username already exists", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

}

