using ShoppingList.ViewModel;

namespace ShoppingList.View;

public partial class ManageShoppingListPage : ContentPage
{
    private ManageShoppingListViewModel ManageShoppingListViewModel;

	public ManageShoppingListPage(ManageShoppingListViewModel manageShoppingListViewModel)
	{
		InitializeComponent();

		BindingContext = manageShoppingListViewModel;

        this.ManageShoppingListViewModel = manageShoppingListViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        ManageShoppingListViewModel.OnNavigatedTo();
    }
}
