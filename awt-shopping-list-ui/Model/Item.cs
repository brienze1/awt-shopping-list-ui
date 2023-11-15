using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingList.Model
{
	public partial class Item : ObservableObject
    {
        public Item(string name)
        {
            this.name = name;
            this.quantity = 1;
        }

        [ObservableProperty]
        [property: JsonPropertyName("name")]
        public string name;
        [ObservableProperty]
        [property: JsonPropertyName("quantity")]
        public int quantity;
    }
}

