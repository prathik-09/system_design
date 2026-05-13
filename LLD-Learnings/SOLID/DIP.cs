using System;

// Abstraction (Interface)
public interface IDatabase
{
    void Save(string data);
}

// MySQL implementation (Low-level module)
public class MySQLDatabase : IDatabase
{
    public void Save(string data)
    {
        Console.WriteLine(
            "Executing SQL Query: INSERT INTO users VALUES('" +
            data + "');"
        );
    }
}

// MongoDB implementation (Low-level module)
public class MongoDBDatabase : IDatabase
{
    public void Save(string data)
    {
        Console.WriteLine(
            "Executing MongoDB Function: db.users.insert({ name: '" +
            data + "' })"
        );
    }
}

// High-level module (loosely coupled through Dependency Injection)
public class UserService
{
    private readonly IDatabase db;

    // Constructor Injection
    public UserService(IDatabase database)
    {
        db = database;
    }

    public void StoreUser(string user)
    {
        db.Save(user);
    }
}

public class DIPFollowed
{
    public static void Main(string[] args)
    {
        IDatabase mysql = new MySQLDatabase();
        IDatabase mongodb = new MongoDBDatabase();

        UserService service1 = new UserService(mysql);
        service1.StoreUser("Aditya");

        UserService service2 = new UserService(mongodb);
        service2.StoreUser("Rohit");
    }
}