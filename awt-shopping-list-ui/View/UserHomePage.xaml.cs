using ShoppingList.ViewModel;

namespace ShoppingList.View;

public partial class UserHomePage : ContentPage
{
    private UserHomeViewModel userHomeViewModel;

    public UserHomePage(UserHomeViewModel userHomeViewModel)
	{
		InitializeComponent();

		BindingContext = userHomeViewModel;

        this.userHomeViewModel = userHomeViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Dispatcher.DispatchAsync(userHomeViewModel.OnNavigatedTo);
    }
}
