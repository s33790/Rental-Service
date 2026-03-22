namespace RentalService.Users;

public class Student : Person
{
    private string indeks;
    private int yearOfStart;
    
    public Student(string firstName, string lastName, string dateOfBirth, string indeks, int yearOfStart) : base(firstName, lastName, dateOfBirth)
    {
        this.indeks = indeks;
        this.yearOfStart = yearOfStart;
    }
    
    public override int GetMaxRentals()
    {
        return 2;
    }
}