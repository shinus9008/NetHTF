namespace NetHTF.Devices.Diagrams.Metadata.Box
{
    public sealed class BoxMetadata : IComponentMetadata
    {
        public BoxMetadata(string name)
        {
            Name = name;
            Sockets = new List<Socket>();
        }

        public string Name { get; }

        public string? Description { get; set; }

        public IList<Socket> Sockets { get; set; }
    }
}
