using ShoppingList.ViewModel;

namespace ShoppingList.View;

public partial class CreateUserPage : ContentPage
{
    public CreateUserPage(CreateUserViewModel createUserViewModel)
    {
        InitializeComponent();

        BindingContext = createUserViewModel;
    }
}
