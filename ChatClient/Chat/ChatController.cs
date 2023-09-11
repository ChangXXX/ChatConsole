

using ChatClient.Login;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatClient.Chat;

public class ChatController
{

    private readonly HubConnection _connection;
    private readonly IUserService _userService;
    private readonly User _user;
    private static string SendMessageToAll = "SendMessageToAll";
    private static string ReceiveAllMessage = "ReceiveAllMessage";
    private static string ReceiveSystemMessage = "ReceiveSystemMessage";
    private static string Divider = "--------------------------------";

    public ChatController(IUserService userService, User user) {
        _user = user;
        _userService = userService;

        _connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7239/chatHub/", options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(_user.Jwt);
            })
            .WithAutomaticReconnect()
            .Build();

        _connection.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await _connection.StartAsync();
        };

        _userService.SetAuthorization(_user.Jwt);
        setHubMsg();
    }

    private void setHubMsg()
    {
        _connection.On<string, string>(ReceiveAllMessage, (user, msg) =>
        {
            Console.WriteLine(Divider);
            Console.WriteLine($"{user}: {msg}");
            Console.WriteLine(Divider);
        });

        _connection.On<string>(ReceiveSystemMessage, (msg) =>
        {
            Console.WriteLine(Divider);
            Console.WriteLine($"시스템 메세지: {msg}");
            Console.WriteLine(Divider);
        });
    }

    public async Task run()
    {
        await _connection.StartAsync();
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine(Divider);
            Console.WriteLine($"{_user.Name}님 안녕하세요 아래 항목을 골라주세요");
            Console.WriteLine("전체에게 메세지 보내기 :: 1");
            Console.WriteLine("채팅방 만들기 :: 2");
            Console.WriteLine("활성화된 채팅방 보기 :: 3");
            Console.WriteLine("유저리스트 보기 :: 4");
            Console.WriteLine("종료를 원하시면 아무 텍스트나 입력해주세요");
            Console.WriteLine(Divider);
            var behavior = Enum.Parse(typeof(InputBehavior), Console.ReadLine(), true);

            switch (behavior)
            {
                case InputBehavior.SendAll:
                    sendAll();
                    break;
                case InputBehavior.CreateRoom:
                    if (createRoom())
                    {
                        // TODO move chat room
                    }
                    break;
                case InputBehavior.ActivationRoom:
                    break;
                case InputBehavior.GetUsers:
                    printUsers(await _userService.GetUsers());
                    break;
                default:
                    isRunning = false;
                    break;
            }
        }
    }

    private bool createRoom()
    {
        return false;
    }

    private void printUsers(List<string> users)
    {
        Console.WriteLine(Divider);
        Console.WriteLine("유저 목록");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {users[i]}");
        }
        Console.WriteLine(Divider);
    }

    private async void sendAll()
    {
        try
        {
            string msg = getMsg();
            await _connection.InvokeAsync(SendMessageToAll, _user.Name, msg);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private string getMsg()
    {
        Console.WriteLine("보내실 메세지를 입력해주세요");
        string msg = Console.ReadLine();
        if (string.IsNullOrEmpty(msg))
        {
            msg = getMsg();
        }

        return msg;
    }
}
