
using RentalService.Service;
using RentalService.Users;

UserRegistry registry = new UserRegistry();

while (true)
{
    Console.WriteLine("0. EXIT\n" +
                      "1. Add a new user\n" +
                      "2. Add new device.\n" +
                      "3. Display the list of all devices with current status.\n" +
                      "4. Display only devices available for rent. \n" +
                      "5. Rent device to a user.\n"+
                      "6. Return device with calculation of any late fees\n" +
                      "7. Mark device as unavailable due to malfunction or service\n" +
                      "8. Display active rentals for a specific user.\n" +
                      "9. Display list of overdue rentals\n" +
                      "10. Generate rental report"
                      );

    var choice =  int.Parse(Console.ReadLine());

    if (choice == 0)
    {
        break;
    }

    switch (choice)
    {
        case 1:
            addUserMenu(registry);
            break;
        
        
    }

    Console.WriteLine($"Your choice: {choice}");
    
}

void addUserMenu(UserRegistry registry)
{
    Console.WriteLine("firstname: ");
    var firstName = Console.ReadLine();
    Console.WriteLine("lastname: ");
    var lastName = Console.ReadLine();
    Console.WriteLine("date of birth(yyyy-mm-dd): ");
    var dateOfBirth = Console.ReadLine();
    Console.WriteLine("Type: 1. Student | 2. Employee");
    int choosenType =  int.Parse(Console.ReadLine());

    if (choosenType == 1)
    {
        Console.WriteLine("indeks: ");
        var indeks = Console.ReadLine();
        Console.WriteLine("year of starting studies:");
        int yearOfStart = int.Parse(Console.ReadLine());
        registry.AddUser(new Student(firstName, lastName, dateOfBirth, indeks, yearOfStart));
    } else if (choosenType == 2)
    {
        Console.WriteLine("salary: ");
        var indeks = int.Parse(Console.ReadLine());
        registry.AddUser(new Employee(firstName, lastName, dateOfBirth, indeks));
    }
}