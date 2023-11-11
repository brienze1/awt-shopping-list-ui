using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ShoppingList.Model;

namespace ShoppingList.Service;


public class UserService
{

    HttpClient httpClient;
    private String username;
    private String password;
    private String token;

    public UserService()
    {
        httpClient = new HttpClient();
    }

    public async Task CreateUserAsync(User user)
    {
        String url = "localhost";

        string json = JsonSerializer.Serialize(user);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("user not created");
        }

        await AuthenticateUserAsync(user.Username, user.Password);
    }


    public async Task AuthenticateUserAsync(String username, String password)
    {
        this.username = username;
        this.password = password;

        httpClient.DefaultRequestHeaders.Clear();

        //String url = "http://localhost:8080";

        string authroization = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {authroization}");

        var req = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/users/authenticate") { Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()) }; ; 

        var response = await httpClient.SendAsync(req);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("user not authenticated");
        }

        UserAuthentication result = await response.Content.ReadFromJsonAsync<UserAuthentication>();
        this.token = result.Token;
    }
}

