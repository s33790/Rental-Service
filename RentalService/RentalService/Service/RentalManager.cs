using RentalService.Users;

namespace RentalService.Service;

public class RentalManager
{
    private List<Rental> activeRentals = new List<Rental>();
    
    public void rent(Person user, Devices device, int durationDays)
    {
        if (user == null || device == null)
        {
            Console.WriteLine("User or device is null");
            return;
        };

        int countRentByUser = 0;
        int maxRentals = user.GetMaxRentals();

        foreach (var rentalCheck in activeRentals)
        {
            if (rentalCheck.person == user && !rentalCheck.rentalEndDate.HasValue)
            {
                countRentByUser ++;
            }
        }
        
        if (countRentByUser >= maxRentals)
        {
            Console.WriteLine("User reached the rental limit");
            return;
        }

        if (device.GetAvailable() == false)
        {
            Console.WriteLine("Device is not available");
            return;
        }
        
        device.SetAvailable(false);
        
        Rental rental = new Rental(user, device, DateTime.Now, durationDays);
        activeRentals.Add(rental);

        Console.WriteLine("Device rented succesfully");
    }

    public void returnDevice(Person user, Devices device)
    {
        var rental = activeRentals.FirstOrDefault(rental => rental.person == user && rental.device == device && !rental.rentalEndDate.HasValue);

        if (rental != null)
        {
            rental.rentalEndDate = DateTime.Now;
            rental.device.SetAvailable(true);
            Console.WriteLine("Device returned succesfully");
            
            if (!rental.isReturnedOnTime())
            {
                double penalty = rental.CalculatePenalty(5.0);
                Console.WriteLine("LANE RETURN!");
                Console.WriteLine("PENALTY: " + penalty);
            }
            else
            {
                Console.WriteLine("Returned on time");
            }
        }
    }

    public void displayUserRentals(Person user)
    {
        var rentals = activeRentals.Where(rental => rental.person == user && !rental.rentalEndDate.HasValue).ToList();

        if (rentals.Count == 0)
        {
            Console.WriteLine("No courrent rentals");
        }
        else
        {
            Console.WriteLine($"Active user {user} rentals: ");
            foreach (var rental in rentals)
            {
                Console.WriteLine(rental.ToString());
            }
        }

    }
}