namespace RentalService;

public class Devices
{
    private static int newId = 1; //zmienic na generowanie
    private int Id { get; set; }
    private string manufacturer { get; set; }
    private string EAN { get; set; }
    private  bool available { get; set; }
    private bool isUnderService { get; set; }

    public Devices(string manufacturer, string EAN, bool available)
    {
        Id = newId++;
        this.manufacturer = manufacturer;
        this.EAN = EAN;
        this.available = available;
        this.isUnderService = false;
    }

    public override string ToString()
    {
        string status = available ? "Available" : (isUnderService ? "Service" : "Rented");
        
        return $"ID: {Id} | status: {status} | Manufacturer: {manufacturer} | EAN: {EAN}";
    }
    
    public bool GetAvailable() 
    {
        return this.available;
    }
}