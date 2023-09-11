using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Chat;

public enum InputBehavior
{
    SendAll = 1,
    CreateRoom = 2,
    ActivationRoom = 3,
    GetUsers = 4
}
