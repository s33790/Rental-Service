namespace RentalService.Service;

public class DeviceRegistry
{
    private List <Devices> devices = new List<Devices>();
    
    public void AddDevice(Devices device)
    {
        devices.Add(device);
        Console.WriteLine("Device added correctly");
    }
    
    public void DisplayAllDevices()
    {
        if (devices.Count == 0)
        {
            Console.WriteLine("No devices found");
        }
        
        foreach (Devices device in devices)
        {
            Console.WriteLine(device);
        }
    }
    
    public void DisplayAvailableDevices()
    {
        var available = devices.Where(d => d.GetAvailable()).ToList();

        if (!available.Any())
        {
            Console.WriteLine("No available devices found.");
            return;
        }
        
        foreach (var device in available)
        {
            Console.WriteLine(device);
        }
    }

    public Devices GetDeviceById(int deviceId)
    {
        return devices.FirstOrDefault(d => d.Id == deviceId);
    }
}