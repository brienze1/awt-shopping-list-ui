using System.Diagnostics;
using ShoppingList.Service;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingList.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    private UserService userService;


    [ObservableProperty]
    String username;

    [ObservableProperty]
    String password;

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


        } catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "User could not log in", "Try again");
        }
        finally
        {
            IsWorking = false;
        }
    }

}

