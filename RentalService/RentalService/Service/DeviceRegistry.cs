namespace RentalService.Service;

public class DeviceRegistry
{
    private List <Devices> _devices = new List<Devices>();
    
    public void AddDevice(Devices device)
    {
        _devices.Add(device);
        Console.WriteLine("Device added correctly");
    }
    
    public void DisplayAllDevices()
    {
        if (_devices.Count == 0)
        {
            Console.WriteLine("No devices found");
        }
        
        foreach (Devices device in _devices)
        {
            Console.WriteLine(device);
        }
    }
    
    public void DisplayAvailableDevices()
    {
        if (_devices.Count == 0)
        {
            Console.WriteLine("No devices found");
        }
        
        foreach (Devices device in _devices)
        {
            if (device.GetAvailable() == true)
            {
                Console.WriteLine(device);

            }
        }
    }
}