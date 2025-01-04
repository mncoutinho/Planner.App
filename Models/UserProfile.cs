namespace Planner.App.Models;
public class UserProfile
{
    public UserProfile(string name, string nickName)
    {
        Name = name;
        NickName = nickName;
        CreatedAt = DateTime.Now;
    }

    protected UserProfile(string name, string nickName, DateTime createdAt)
    {
        Name = name;
        NickName = nickName;
        CreatedAt = createdAt;
    }
    
    public string Name { get; protected set; }
    public string NickName { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
}
