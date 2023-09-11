
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ChatClient.Chat;
class UserService: IUserService
{
    private static string _location = "Users";
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Base");
    }

    public void SetAuthorization(string jwt)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
    }

    public async Task<List<string>> GetUsers()
    {
        using (var response = await _httpClient.GetAsync($"{_location}"))
        {
            var users = new List<string>();
            if (response.IsSuccessStatusCode)
            {
                
                users = response.Content.ReadFromJsonAsync<List<string>>().Result;
            }
            return users;
        }
    }
}

