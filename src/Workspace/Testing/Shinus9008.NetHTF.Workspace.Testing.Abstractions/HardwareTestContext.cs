using Shinus9008.NetHTF.Workspace.Features;

namespace Shinus9008.NetHTF.Workspace.Testing
{
    /// <summary>
    /// Encapsulate all information about hardware test
    /// </summary>
    public abstract class HardwareTestContext
    {
        /// <summary>
        /// Get <see cref="IFeatureCollection"/>
        /// </summary>
        public abstract IFeatureCollection Features { get; }
    }
}
