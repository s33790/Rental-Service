namespace RentalService;

public class Devices
{
    private int newId = 1; //zmienic na generowanie
    private int Id { get; set; }
    private string manufacturer { get; set; }
    private string EAN { get; set; }
    private  bool available { get; set; }

    public Devices(string manufacturer, string EAN, bool available)
    {
        Id = newId++;
        this.manufacturer = manufacturer;
        this.EAN = EAN;
        this.available = available;
    }
}