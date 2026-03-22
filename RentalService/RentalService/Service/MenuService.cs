namespace RentalService.Service;
using RentalService;
using RentalService.Users;

public class MenuService
{

    UserRegistry userRegistry = new UserRegistry();
    DeviceRegistry deviceRegistry = new DeviceRegistry();
    RentalManager rentalManager = new RentalManager();

    public void Run() {
        while (true)
        {
            Console.WriteLine("0. EXIT\n" +
                              "1. Add a new user\n" +
                              "2. Add new device.\n" +
                              "3. Display the list of all devices with current status.\n" +
                              "4. Display only devices available for rent. \n" +
                              "5. Rent device to a user.\n" +
                              "6. Return device with calculation of any late fees\n" +
                              "7. Mark device as unavailable due to malfunction or service\n" +
                              "8. Display active rentals for a specific user.\n" +
                              "9. Display list of overdue rentals\n" +
                              "10. Generate rental report"
        );

            var choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                break;
            }

            switch (choice)
            {
                case 1:
                    AddUserMenu(userRegistry);
                    break;
                case 2:
                    AddDeviceMenu(deviceRegistry);
                    break;
                case 3:
                    deviceRegistry.DisplayAllDevices();
                    break;
                case 4:
                    deviceRegistry.DisplayAvailableDevices();
                    break;
                case 5:
                    RentDeviceMenu(userRegistry, deviceRegistry, rentalManager);
                    break;
                case 6:
                    ReturnDeviceMenu(userRegistry, deviceRegistry, rentalManager);
                    break;
                case 7:
                    setServiceStatus(deviceRegistry);
                    break;
                case 8:
                    DisplayUserRentalsMenu(userRegistry, rentalManager);
                    break;
                case 9:
                    break;
                case 10:
                    Console.WriteLine("All USERS:");
                    userRegistry.DisplayAllUsers();
                    Console.WriteLine("All DEVICES:");
                    deviceRegistry.DisplayAllDevices();
                    break;
        }
        Console.WriteLine($"Your choice: {choice}");
        }
    }

void AddUserMenu(UserRegistry registry)
    {
        Console.WriteLine("firstname: ");
        var firstName = Console.ReadLine().ToUpper();
        Console.WriteLine("lastname: ");
        var lastName = Console.ReadLine().ToUpper();
        Console.WriteLine("date of birth(yyyy-mm-dd): ");
        var dateOfBirth = Console.ReadLine();
        Console.WriteLine("Type: 1. Student | 2. Employee");
        int choosenType = int.Parse(Console.ReadLine());

        if (choosenType == 1)
        {
            Console.WriteLine("indeks: ");
            var indeks = Console.ReadLine().ToLower();
            Console.WriteLine("year of starting studies:");
            int yearOfStart = int.Parse(Console.ReadLine());
            registry.AddUser(new Student(firstName, lastName, dateOfBirth, indeks, yearOfStart));
        }
        else if (choosenType == 2)
        {
            Console.WriteLine("salary: ");
            var indeks = int.Parse(Console.ReadLine());
            registry.AddUser(new Employee(firstName, lastName, dateOfBirth, indeks));
        }
        else
        {
            Console.WriteLine("invalid choice");
        }
    }

    void AddDeviceMenu(DeviceRegistry registry)
    {
        Console.WriteLine("manufacturer: ");
        var manufacturer = Console.ReadLine().ToUpper();
        Console.WriteLine("EAN: ");
        var EAN = Console.ReadLine();
        Console.WriteLine("Available: (true/false)");
        bool choosenAvailability = bool.Parse(Console.ReadLine());
        Console.WriteLine("Choose type: 1. Laptop | 2. Projector | 3. Camera:");
        int choosenType = int.Parse(Console.ReadLine());

        if (choosenType == 1)
        {
            Console.WriteLine("processor: ");
            var processor = Console.ReadLine();
            Console.WriteLine("RAM: ");
            var ram = int.Parse(Console.ReadLine());
            Console.WriteLine("storage size: ");
            var storageSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Operating system: ");
            var operatingSystem = Console.ReadLine().ToUpper();

            registry.AddDevice(new Laptop(manufacturer, EAN, choosenAvailability, processor, ram, storageSize,
                operatingSystem));
        }
        else if (choosenType == 2)
        {
            Console.WriteLine("resolution: ");
            var resolution = Console.ReadLine();
            Console.WriteLine("Brightness: ");
            var brightness = int.Parse(Console.ReadLine());
            Console.WriteLine("Speaker: (true/false)");
            bool hasSpeaker = bool.Parse(Console.ReadLine());

            registry.AddDevice(
                new Projector(manufacturer, EAN, choosenAvailability, resolution, brightness, hasSpeaker));
        }
        else if (choosenType == 3)
        {
            Console.WriteLine("Resolution: ");
            var resolution = Console.ReadLine();
            Console.WriteLine("Frame rate: ");
            var frameRate = int.Parse(Console.ReadLine());
            Console.WriteLine("Speaker: (true/false)");
            bool hasSpeaker = bool.Parse(Console.ReadLine());

            registry.AddDevice(new Camera(manufacturer, EAN, choosenAvailability, resolution, frameRate, hasSpeaker));
        }
        else
        {
            Console.WriteLine("invalid choice");
        }
    }

    void RentDeviceMenu(UserRegistry user, DeviceRegistry device, RentalManager rentalManager)
    {
        Console.WriteLine("Enter user ID:");
        int userId = int.Parse(Console.ReadLine());
        var checkUser = user.GetUserById(userId);

        if (checkUser == null)
        {
            Console.WriteLine("User not found");
        }

        Console.WriteLine("Enter device ID:");
        int deviceId = int.Parse(Console.ReadLine());
        var checkDevice = device.GetDeviceById(deviceId);

        if (checkDevice == null)
        {
            Console.WriteLine("Device not found");
            return;
        }

        Console.WriteLine("For how many days?: ");
        int durationDays = int.Parse(Console.ReadLine());

        rentalManager.rent(checkUser, checkDevice, durationDays);
    }

    void DisplayUserRentalsMenu(UserRegistry user, RentalManager rentalManager)
    {
        Console.WriteLine("Enter user ID:");
        int userId = int.Parse(Console.ReadLine());

        var checkUser = user.GetUserById(userId);
        if (checkUser == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        rentalManager.displayUserRentals(checkUser);
    }

    void ReturnDeviceMenu(UserRegistry user, DeviceRegistry device, RentalManager rentalManager)
    {
        Console.WriteLine("Enter user ID:");
        int userId = int.Parse(Console.ReadLine());

        var checkUser = user.GetUserById(userId);
        if (checkUser == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        Console.WriteLine("Enter device ID:");
        int deviceId = int.Parse(Console.ReadLine());
        var checkDevice = device.GetDeviceById(deviceId);

        if (checkDevice == null)
        {
            Console.WriteLine("Device not found");
            return;
        }

        rentalManager.returnDevice(checkUser, checkDevice);
    }

    void setServiceStatus(DeviceRegistry deviceRegistry)
    {
        Console.WriteLine("Enter device ID:");
        int deviceId = int.Parse(Console.ReadLine());
        
        var device = deviceRegistry.GetDeviceById(deviceId);
        if (device == null)
        {
            Console.WriteLine("Device not found.");
            return;
        }

        if (!device.GetAvailable() &&  !device.GetIsUnderService())
        {
            Console.WriteLine("Service not available. Device currently RENTED");
            return;
        }

        Console.WriteLine("1 Sent to service | 2. Back from service");
        int choice = int.Parse(Console.ReadLine());
        
        if (choice == 1)
        {
            device.SetIsUnderService(true);
            Console.WriteLine("Device is under service");
        } else if (choice == 2)
        {
            device.SetIsUnderService(false);
            Console.WriteLine("Device is back from   service");
        }
    } 
}