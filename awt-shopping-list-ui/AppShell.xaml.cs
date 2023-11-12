
using ShoppingList.View;

namespace awt_shopping_list_ui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CreateUserPage), typeof(CreateUserPage));
        Routing.RegisterRoute(nameof(UserHomePage), typeof(UserHomePage));
    }
}

