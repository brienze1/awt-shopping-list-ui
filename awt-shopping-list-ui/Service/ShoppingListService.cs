using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace ShoppingList.Service;

public class ShoppingListService
{
    HttpClient httpClient;
    private UserService userService;

    public ShoppingListService(UserService userService)
    {
        httpClient = new HttpClient();
        this.userService = userService;
    }

    internal async Task<List<Model.ShoppingList>> GetShoppingListsAsync()
    {
        httpClient.DefaultRequestHeaders.Clear();

        string token = this.userService.GetToken();

        httpClient.DefaultRequestHeaders.Add("Authorization", token);

        var req = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/shopping-lists");

        var response = await httpClient.SendAsync(req);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("user not authenticated");
        }

        return await response.Content.ReadFromJsonAsync<List<Model.ShoppingList>>();
    }
}

