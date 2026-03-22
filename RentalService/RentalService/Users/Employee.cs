namespace RentalService.Users;

public class Employee : Person
{
    private int salary { get; set; }
    
    public Employee(string firstName, string lastName, string dateOfBirth, int salary) : base(firstName, lastName, dateOfBirth)
    {
        this.salary = salary;
    }
    
    public override int GetMaxRentals()
    {
        return 5;
    }
}