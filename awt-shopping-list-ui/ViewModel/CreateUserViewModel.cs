using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingList.Model;
using ShoppingList.Service;

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
        await userService.CreateUserAsync(new User(Username, Password, FirstName, LastName));
    }

}

