namespace Shinus9008.NetHTF.Workspace.Testing
{
    /// <summary>
    /// Define hardware testing infrastructure
    /// </summary>
    public interface IHardwareTest : IAsyncDisposable
    {
        /// <summary>
        /// Run hardware testing 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Run(CancellationToken cancellationToken);
    }
}
