namespace Shinus9008.NetHTF.Workspace.Testing
{
    /// <summary>
    /// Extension methods for adding terminal middle-ware.
    /// </summary>
    public static class RunExtensions
    {
        /// <summary>
        /// Adds a terminal middle-ware delegate to the application's request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="handler">A delegate that handles the request.</param>
        public static void Run(this IHardwareTestBuilder app, HardwareTestDelegate handler)
        {
            ArgumentNullException.ThrowIfNull(app);
            ArgumentNullException.ThrowIfNull(handler);

            app.Use(_ => handler);
        }
    }
}
