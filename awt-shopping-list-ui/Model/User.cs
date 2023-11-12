using System.Text.Json.Serialization;

namespace ShoppingList.Model
{
	public class User
	{

        public User(String username, String password, String firstName, String lastName)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        [JsonPropertyName("username")]
        public String Username { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }
        [JsonPropertyName("first_name")]
        public String FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public String LastName { get; set; }
    }
}

