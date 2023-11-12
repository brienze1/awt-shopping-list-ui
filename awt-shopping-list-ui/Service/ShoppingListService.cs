using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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

    internal async Task<Model.ShoppingList> UpdateShoppingListAsync(Model.ShoppingList shoppingList)
    {
        httpClient.DefaultRequestHeaders.Clear();

        string token = this.userService.GetToken();
        httpClient.DefaultRequestHeaders.Add("Authorization", token);

        string json = JsonSerializer.Serialize(shoppingList);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PutAsync($"http://localhost:8080/shopping-lists/{shoppingList.Id}", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("user not authenticated");
        }

        return await response.Content.ReadFromJsonAsync<Model.ShoppingList>();
    }

    internal async Task<Model.ShoppingList> CreateShoppingListAsync(Model.ShoppingList shoppingList)
    {
        httpClient.DefaultRequestHeaders.Clear();

        string token = this.userService.GetToken();
        httpClient.DefaultRequestHeaders.Add("Authorization", token);

        string json = JsonSerializer.Serialize(shoppingList);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://localhost:8080/shopping-lists", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("user not authenticated");
        }

        return await response.Content.ReadFromJsonAsync<Model.ShoppingList>();
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

    internal async Task DeleteShoppingList(string id)
    {
        httpClient.DefaultRequestHeaders.Clear();

        string token = this.userService.GetToken();
        httpClient.DefaultRequestHeaders.Add("Authorization", token);

        var req = new HttpRequestMessage(HttpMethod.Delete, $"http://localhost:8080/shopping-lists/{id}");

        var response = await httpClient.SendAsync(req);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error occurred while trying to delete shopping list");
        }
    }
}

