
namespace ChatClient.Login;

public interface ILoginService
{

    public Task<User?> Login(string username, string password);
}