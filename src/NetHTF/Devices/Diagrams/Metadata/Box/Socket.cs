namespace NetHTF.Devices.Diagrams.Metadata.Box
{
    public class Socket
    {
        public Socket(string name, IEnumerable<Pin> enumerablePin)
        {
            Name = name;
            Pins = new List<Pin>(enumerablePin);
        }

        public IList<Pin> Pins { get; }
        public string Name { get; }

        public static Socket WithePin(string soketName, params string[] pinNames) =>
            new Socket(soketName, pinNames.Select(name => new Pin(name)));           
    }
}
