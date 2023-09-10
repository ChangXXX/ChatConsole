using ChatClient.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChatClient.Chat;
class UserService: IUserService
{
    private static string _location = "Users";
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Base");
    }

    public async Task<List<string>> GetUsers()
    {
        using (var response = await _httpClient.GetAsync($"{_location}"))
        {
            var users = new List<string>();
            if (response.IsSuccessStatusCode)
            {
                var body = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(body);
            }
            return users;
        }
    }
}

