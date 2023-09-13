using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Chat;

public class Room
{
    public Room()
    {
    }

    public Room(long id, List<string> users)
    {
        this.Id = id;
        this.Users = users;
    }
    public long Id { get; set; }
    public List<string> Users { get; set; } = new();
}
