namespace Shinus9008.NetHTF.Workspace.Hardware.Mapping
{
    public interface IHardwareMappingFeature
    {
        T Get<T>(string mappedPattern) where T : class, IHardwareActivity;
    }
}
