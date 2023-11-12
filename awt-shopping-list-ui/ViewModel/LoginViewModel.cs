using System.Diagnostics;
using ShoppingList.Service;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ShoppingList.View;

namespace ShoppingList.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    private UserService userService;


    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    public LoginViewModel(UserService userService)
    {
        Title = "Login";
        this.userService = userService;
    }

    [RelayCommand]
    async Task AuthenticateUserAsync()
    {
        if (IsWorking)
        {
            return;
        }

        try
        {
            IsWorking = true;

            await userService.AuthenticateUserAsync(Username, Password);

            await Shell.Current.GoToAsync($"{nameof(UserHomePage)}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "User could not log in", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

    [RelayCommand]
    async Task GoToCreateUserPageAsync()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(CreateUserPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Try again");
        }
    }

}
