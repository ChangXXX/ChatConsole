
namespace ChatClient.Login;

public class User
{

    public User(string Name, string Password)
    {
        this.Name = Name;
        this.Password = Password;
    }

    public string Name { get; set; }
    public String Password { get; set; }

}