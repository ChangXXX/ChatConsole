
using System.Net;
using System.Net.Http.Headers;

namespace ChatClient.Login;

public class LoginService : ILoginService
{
    private static string _location = "Users/";
    private readonly HttpClient _httpClient;

    public LoginService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Base");
    }

    public async Task<User?> Login(string name, string password)
    {
        using (var response = await _httpClient.GetAsync($"{_location}{name}/{password}"))
        {
            User user = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jwt = response.Headers.GetValues("Jwt").FirstOrDefault();
                user = new User(name, password);
                user.Jwt = jwt;
                return user;
            }
            else
            {
                return user;
            }
        }
    }
}