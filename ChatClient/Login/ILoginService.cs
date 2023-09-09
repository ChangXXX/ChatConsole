
namespace ChatClient.Login;

public interface ILoginService
{

    public Task<HttpResponseMessage> Login(string username, string password);
}