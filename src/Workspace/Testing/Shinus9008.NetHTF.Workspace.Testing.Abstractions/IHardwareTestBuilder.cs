using Shinus9008.NetHTF.Workspace.Features;

namespace Shinus9008.NetHTF.Workspace.Testing
{
    /// <summary>
    /// Define a class that provide the mechanism to configure hardware test's pipeline
    /// </summary>
    public interface IHardwareTestBuilder
    {
        /// <summary>
        /// Gets or sets the <see cref="IServiceProvider"/> that provides access to the application's service container.
        /// </summary>
        IServiceProvider ApplicationServices { get; set; }

        /// <summary>
        /// Gets the set of hardware test features the application's server provides.
        /// </summary>
        /// <remarks>
        /// An empty collection is returned if a server wasn't specified for the application builder.
        /// </remarks>
        IFeatureCollection ServerFeatures { get; }

        /// <summary>
        /// Gets a key/value collection that can be used to share data between middle-ware.
        /// </summary>
        IDictionary<string, object?> Properties { get; }

        /// <summary>
        /// Adds a middle-ware delegate to the application's request pipeline.
        /// </summary>
        /// <param name="middleware">The middle-ware delegate.</param>
        /// <returns>The <see cref="IHardwareTestBuilder"/>.</returns>
        IHardwareTestBuilder Use(Func<HardwareTestDelegate, HardwareTestDelegate> middleware);

        /// <summary>
        /// Creates a new <see cref="IHardwareTestBuilder"/> that shares the <see cref="Properties"/> of this
        /// <see cref="IHardwareTestBuilder"/>.
        /// </summary>
        /// <returns>The new <see cref="IApplicationBuilder"/>.</returns>
        IHardwareTestBuilder New();

        /// <summary>
        /// Builds the delegate used by this application to process hardware test.
        /// </summary>
        /// <returns>The request handling delegate.</returns>
        HardwareTestDelegate Build();
    }
}
