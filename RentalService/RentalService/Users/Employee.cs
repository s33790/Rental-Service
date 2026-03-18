namespace RentalService.Users;

public class Employee : Person
{
    private int salary { get; set; }
    
    public Employee(string firstName, string lastName, DateTime dateOfBirth, int salary) : base(firstName, lastName, dateOfBirth)
    {
        this.salary = salary;
    }

    
    
}