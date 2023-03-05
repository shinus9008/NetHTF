namespace NetHTF.Devices.Diagrams
{
    /// <summary>
    /// Diagram component ( Virtual device info )
    /// </summary>
    public class DiagramComponent
    {
        public DiagramComponent(string name)
        {
            Name = name;
            Metadata = new Dictionary<Type, IComponentMetadata>();
        }

        /// <summary>
        /// Name of component
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Meta-data of component
        /// </summary>
        public Dictionary<Type, IComponentMetadata> Metadata { get; }
    }
}
