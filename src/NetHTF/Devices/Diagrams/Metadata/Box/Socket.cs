namespace NetHTF.Devices.Diagrams.Metadata.Box
{
    public class Socket
    {
        public Socket(string name)
        {
            Name = name;
        }

        public IList<Pin> Pins { get; }
        public string Name { get; }
        public static Socket WithePin(string soketName, string pinName) =>
            new Socket(soketName)
            {
                Pins =
                {
                    new Pin(pinName)
                }
            };
    }
}
