namespace RentalService;

public class Projector : Devices
{
    private string resolution { get; set; }
    private int brightness { get; set; }
    private bool hasSpeaker { get; set; }
    
    public Projector(string manufacturer, string EAN, bool available, string resolution, int brightness, bool hasSpeaker) 
        : base(manufacturer, EAN, available)
    {
        this.resolution = resolution;
        this.brightness = brightness;
        this.hasSpeaker = hasSpeaker;
    }
}