namespace Shinus9008.NetHTF.Workspace.Testing.Extensions
{
    /// <summary>
    /// Extension methods for adding middleware.
    /// </summary>
    public static class UseExtensions
    {
        /// <summary>
        /// Adds a middleware delegate defined in-line to the application's request pipeline.
        /// If you aren't calling the next function, use <see cref="RunExtensions.Run(IApplicationBuilder, RequestDelegate)"/> instead.
        /// <para>
        /// Prefer using <see cref="Use(IHardwareTestBuilder, Func{HttpContext, RequestDelegate, Task})"/> for better performance as shown below:
        /// <code>
        /// app.Use((context, next) =>
        /// {
        ///     return next(context);
        /// });
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="middleware">A function that handles the request and calls the given next function.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IHardwareTestBuilder Use(this IHardwareTestBuilder app, Func<HardwareTestContext, Func<Task>, Task> middleware)
        {
            return app.Use(next =>
            {
                return context =>
                {
                    Func<Task> simpleNext = () => next(context);
                    return middleware(context, simpleNext);
                };
            });
        }

        /// <summary>
        /// Adds a middleware delegate defined in-line to the application's request pipeline.
        /// If you aren't calling the next function, use <see cref="RunExtensions.Run(IHardwareTestBuilder, HardwareTestDelegate)"/> instead.
        /// </summary>
        /// <param name="app">The <see cref="IHardwareTestBuilder"/> instance.</param>
        /// <param name="middleware">A function that handles the request and calls the given next function.</param>
        /// <returns>The <see cref="IHardwareTestBuilder"/> instance.</returns>
        public static IHardwareTestBuilder Use(this IHardwareTestBuilder app, Func<HardwareTestContext, HardwareTestDelegate, Task> middleware)
        {
            return app.Use(next => context => middleware(context, next));
        }
    }
}
