using RentalService.Users;

namespace RentalService.Service;

public class UserRegistry
{
    private List<Person> users = new List<Person>();

    public void AddUser(Person person)
    {
        users.Add(person);
        Console.WriteLine("User added correctly");
    }

    public Person GetUserById(int userId)
    {
        return users.FirstOrDefault(x => x.idUser == userId);
    }
    
    public void DisplayAllUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("No userss found");
        }
        
        foreach (var user in users)
        {
            Console.WriteLine(user.ToString());
        }
    }
}