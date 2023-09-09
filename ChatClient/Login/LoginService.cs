
namespace ChatClient.Login;

public class LoginService : ILoginService
{
    private string _location = "Users/";
    private readonly HttpClient _httpClient;

    public LoginService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Base");
    }

    public async Task<HttpResponseMessage> Login(string name, string password) => 
        await _httpClient.GetAsync( $"{_location}{name}/{password}");
}