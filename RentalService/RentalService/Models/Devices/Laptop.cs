namespace RentalService;

public class Laptop : Device
{
    private string processor { get; set; }
    private int RAM { get; set; }
    private int storageSize { get; set; }
    private string operatingSystem { get; set; }

    public Laptop(string manufacturer, string EAN, bool available, string processor, int RAM, int storageSize, string operatingSystem ) : base(manufacturer, EAN, available)
    {
        this.processor = processor;
        this.RAM = RAM;
        this.storageSize = storageSize;
        this.operatingSystem = operatingSystem;
    }

}