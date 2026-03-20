using RentalService.Users;

namespace RentalService.Service;

public class UserRegistry
{
    private List<Person> _users = new List<Person>();

    public void AddUser(Person person)
    {
        _users.Add(person);
        Console.WriteLine("User added correctly");
    }

    // public List<Person> GetAllUsers()
    // {
    //     return  _users;
    // }
}