namespace NetHTF.Devices
{
    public class DeviceDiagram
    {
        public DeviceDiagram(string name)
        {
            Name = name;
            Devices = new List<DeviceInfo>();
        }

        public string Name { get; }

        //TODO: Read only
        public IList<DeviceInfo> Devices { get; }

        public void Add(string name)
        {
            //TODO: should not be repeated
            Devices.Add(new DeviceInfo(name));
        }
    }
}
