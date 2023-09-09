
namespace ChatClient.Login;

public class LoginController
{

    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async void Login()
    {
        var name = getInputName();
        var pwd = getInputPwd();

        var res = await _loginService.Login(name, pwd);
        Console.WriteLine(res);
    }

    private string getInputName()
    {
        Console.Write("사용자 이름을 입력해주세요 : ");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            name = getInputName();
        }
        return name;
    }

    private string getInputPwd()
    {
        Console.Write("비밀번호를 입력해주세요 : ");
        var pwd = Console.ReadLine();
        if (string.IsNullOrEmpty(pwd))
        {
            pwd = getInputName();
        }
        return pwd;
    }
}