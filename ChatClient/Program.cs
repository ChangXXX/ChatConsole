using ChatClient.Chat;
using ChatClient.Login;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

ServiceCollection collection = new ServiceCollection();

collection.AddHttpClient(
    "Base", options =>
    {
        options.BaseAddress = new Uri("https://localhost:7239/api/");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );
    }
);

collection.AddSingleton<ILoginService, LoginService>();
collection.AddSingleton<IUserService, UserService>();
var provider = collection.BuildServiceProvider();

// login
LoginController login = new LoginController(provider.GetService<ILoginService>());
User currUser = login.Login().GetAwaiter().GetResult();

// chat
ChatController chat = new ChatController(provider.GetService<IUserService>(), currUser);
chat.run().GetAwaiter().GetResult();
