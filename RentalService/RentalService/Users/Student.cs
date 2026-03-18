namespace RentalService.Users;

public class Student : Person
{
    private string indeks;
    private int year;
    
    public Student(string firstName, string lastName, DateTime dateOfBirth, string indeks, int year) : base(firstName, lastName, dateOfBirth)
    {
        this.indeks = indeks;
        this.year = year;
    }
}