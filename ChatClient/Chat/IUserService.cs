using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Chat;

public interface IUserService
{

    public Task<List<String>> GetUsers();
}
