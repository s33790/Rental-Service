using RentalService.Users;

namespace RentalService.Service;

public class Rental
{
    public Person person { get; set; }
    public Devices device  { get; set; }
    public DateTime rentalDate { get; set; }
    public int PlannedRentalInDays { get; set; }
    public DateTime? rentalEndDate { get; set; }
    
    public Rental (Person person, Devices device, DateTime rentalDate, int plannedRentalInDays)
    {
        this.person = person;
        this.device = device;
        this.rentalDate = rentalDate;
        this.PlannedRentalInDays = plannedRentalInDays;
        this.rentalEndDate = null;
    }

    public DateTime getRentalEndDate()
    {
        return rentalDate.AddDays(PlannedRentalInDays);
    }

    public bool isReturnedOnTime()
    {
        if (rentalEndDate == null)
        {
            return true;
        }
        
        return rentalEndDate.Value <= getRentalEndDate();
    }

    public double CalculatePenalty(double dailyRate)
    {
        if (!rentalEndDate.HasValue)
        {
            return 0;
        }
        
        DateTime plannedEndDate = getRentalEndDate();

        if (rentalEndDate > plannedEndDate)
        {
            int daysOfDelay = (rentalEndDate.Value - plannedEndDate).Days;
            
            return dailyRate * daysOfDelay;
        }
        return 0;
    }

    public override string ToString()
    {
        string status;

        if (rentalEndDate != null)
        {
            status = isReturnedOnTime() ? "Zwróconno w terminie" : "Zwrócono PO TERMINIE";
        }
        else
        {
            status = "W trakcie wypożyczenia";
        }
        
        return $"Rent info: from {rentalDate} | for: {PlannedRentalInDays} days |  {device} |  {status}";
    }
}