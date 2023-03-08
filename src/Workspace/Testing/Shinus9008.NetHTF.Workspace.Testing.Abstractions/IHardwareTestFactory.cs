namespace Shinus9008.NetHTF.Workspace.Testing
{
    /// <summary>
    /// Define a class that provide the mechanism to create hardware test
    /// </summary>
    public interface IHardwareTestFactory
    {
        /// <summary>
        /// Create new <see cref="IHardwareTest"/>
        /// </summary>        
        IHardwareTest CreateHardwareTest();
    }
}
