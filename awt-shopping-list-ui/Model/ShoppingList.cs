namespace ShoppingList.Model
{
	public class ShoppingList
	{

        public ShoppingList(string name)
        {
            this.Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }

}

