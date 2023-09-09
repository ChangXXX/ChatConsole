using ChatClient.Login;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection collection = new ServiceCollection();

collection.AddHttpClient(
    "Base", options => options.BaseAddress = new Uri("http://localhost:5100/api/")
);

collection.AddSingleton<ILoginService, LoginService>();
var provider = collection.BuildServiceProvider();

// login
LoginController login = new LoginController(provider.GetService<ILoginService>());
login.Login();

// chat
