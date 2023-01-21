namespace NetHTF.Devices
{
    /// <summary>
    /// Virtual device info
    /// </summary>
    public class DeviceInfo
    {
        public DeviceInfo(string name)
        {
            Name = name;
            Metadata = new Dictionary<Type, IDeivceMetadata>();
        }

        /// <summary>
        /// Name of virtual device
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Meta-data of virtual device
        /// </summary>
        public IDictionary<Type, IDeivceMetadata> Metadata { get; }
    }
}
