using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingList.Model
{
    public partial class ShoppingList : ObservableObject
    {

        public ShoppingList()
        {
            this.Items = new List<Item>();
        }

        [ObservableProperty]
        [property: JsonPropertyName("id")]
        public string id;
        [ObservableProperty]
        [property: JsonPropertyName("name")]
        public string name;
        [ObservableProperty]
        [property: JsonPropertyName("items")]
        public List<Item> items;
    }

}

