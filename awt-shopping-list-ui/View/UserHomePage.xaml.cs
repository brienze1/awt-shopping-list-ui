using ShoppingList.ViewModel;

namespace ShoppingList.View;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(UserHomeViewModel userHomeViewModel)
	{
		InitializeComponent();

		BindingContext = userHomeViewModel;
    }
}
