namespace RentalService;

public class Devices
{
    private static int newId = 1; 
    public int Id { get; set; }
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
        isUnderService = false;
    }

    public override string ToString()
    {
        string status = available ? "Available" : (isUnderService ? "Service" : "Rented");
        
        return $"ID: {Id} | status: {status} | Manufacturer: {manufacturer} | EAN: {EAN}";
    }
    
    public bool GetAvailable() 
    {
        return available;
    }
    
    public void SetAvailable(bool status)
    {
        available = status;
    }

    public void SetIsUnderService(bool status)
    {
        isUnderService = status;
        available = !status;
    }
    
    public bool GetIsUnderService()
    {
        return isUnderService;
    }
}