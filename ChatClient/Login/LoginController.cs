
namespace ChatClient.Login;

public class LoginController
{

    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task<User> Login()
    {
        var name = getInputName();
        var pwd = getInputPwd();

        var user = await _loginService.Login(name, pwd);

        if (user == null)
        {
            Console.WriteLine("로그인 실패");
            user = await Login();
        }

        return user;
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