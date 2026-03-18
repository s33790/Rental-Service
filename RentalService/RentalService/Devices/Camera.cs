namespace RentalService;

public class Camera : Devices
{
    private string resolution { get; set; }
    private int frameRate { get; set; }
    private bool hasSpeaker { get; set; }
    
    
    public Camera(string manufacturer, string EAN, bool available, string resolution, int frameRate, bool hasSpeaker) : base(manufacturer, EAN, available)
    {
        this.resolution = resolution;
        this.frameRate = frameRate;
        this.hasSpeaker = hasSpeaker;
    }
}