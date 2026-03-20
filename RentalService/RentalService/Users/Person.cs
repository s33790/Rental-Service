namespace RentalService.Users;

public class Person
{
    private static int newId = 1; 
    private int idUser { get; set; }
    private string firstName { get; set; }
    private string lastName { get; set; }
    private string dateOfBirth { get; set; }

    public Person(string firstName, string lastName,  string dateOfBirth)
    {
        idUser = newId++;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
    }
}