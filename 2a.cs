using System;
using System.Collections.Generic;

interface IChatMediator
{
    void SendMessage(User sender, string message);
}

interface IUser
{
    string Name { get; }
    void SendMessage(string message);
    void ReceiveMessage(string message);
}

class User : IUser
{
    private readonly string name;
    private readonly IChatMediator mediator;

    public User(string name, IChatMediator mediator)
    {
        this.name = name;
        this.mediator = mediator;
    }

    public string Name => name;

    public void SendMessage(string message)
    {
        Console.WriteLine($"{name} sends message: {message}");
        mediator.SendMessage(this, message);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{name} receives message: {message}");
    }
}

class ChatRoom : IChatMediator
{
    private readonly List<IUser> users = new List<IUser>();

    public void AddUser(IUser user)
    {
        users.Add(user);
    }

    public void SendMessage(IUser sender, string message)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.ReceiveMessage($"{sender.Name}: {message}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var chatRoom = new ChatRoom();

        var user1 = new User("User 1", chatRoom);
        var user2 = new User("User 2", chatRoom);
        var user3 = new User("User 3", chatRoom);

        chatRoom.AddUser(user1);
        chatRoom.AddUser(user2);
        chatRoom.AddUser(user3);

        user1.SendMessage("Hello, everyone!");
    }
}
