using Shinus9008.NetHTF.Workspace.Features;

namespace Shinus9008.NetHTF.Workspace.Testing
{
    public class HardwareTestBuilder : IHardwareTestBuilder
    {
        private const string ServerFeaturesKey = "server.Features";
        private const string ApplicationServicesKey = "application.Services";

        private readonly List<Func<HardwareTestDelegate, HardwareTestDelegate>> _components = new();

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationBuilder"/>.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> for application services.</param>
        public HardwareTestBuilder(IServiceProvider serviceProvider) : this(serviceProvider, new FeatureCollection())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationBuilder"/>.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> for application services.</param>
        /// <param name="server">The server instance that hosts the application.</param>
        public HardwareTestBuilder(IServiceProvider serviceProvider, object server)
        {
            Properties = new Dictionary<string, object?>(StringComparer.Ordinal);
            ApplicationServices = serviceProvider;

            SetProperty(ServerFeaturesKey, server);
        }

        private HardwareTestBuilder(HardwareTestBuilder builder)
        {
            //TODO: Для чего в MVC core используется CopyOnWriteDictionary
            Properties = builder.Properties; //new CopyOnWriteDictionary<string, object?>(, StringComparer.Ordinal);
        }

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> for application services.
        /// </summary>
        public IServiceProvider ApplicationServices
        {
            get
            {
                return GetProperty<IServiceProvider>(ApplicationServicesKey)!;
            }
            set
            {
                SetProperty<IServiceProvider>(ApplicationServicesKey, value);
            }
        }

        /// <summary>
        /// Gets the <see cref="IFeatureCollection"/> for server features.
        /// </summary>
        /// <remarks>
        /// An empty collection is returned if a server wasn't specified for the application builder.
        /// </remarks>
        public IFeatureCollection ServerFeatures
        {
            get
            {
                return GetProperty<IFeatureCollection>(ServerFeaturesKey)!;
            }
        }

        /// <summary>
        /// Gets a set of properties for <see cref="ApplicationBuilder"/>.
        /// </summary>
        public IDictionary<string, object?> Properties { get; }

        private T? GetProperty<T>(string key)
        {
            return Properties.TryGetValue(key, out var value) ? (T?)value : default(T);
        }

        private void SetProperty<T>(string key, T value)
        {
            Properties[key] = value;
        }

        /// <summary>
        /// Adds the middleware to the application request pipeline.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <returns>An instance of <see cref="IApplicationBuilder"/> after the operation has completed.</returns>
        public IHardwareTestBuilder Use(Func<HardwareTestDelegate, HardwareTestDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }

        /// <summary>
        /// Creates a copy of this application builder.
        /// <para>
        /// The created clone has the same properties as the current instance, but does not copy
        /// the request pipeline.
        /// </para>
        /// </summary>
        /// <returns>The cloned instance.</returns>
        public IHardwareTestBuilder New()
        {
            return new HardwareTestBuilder(this);
        }

        /// <summary>
        /// Produces a <see cref="RequestDelegate"/> that executes added middlewares.
        /// </summary>
        /// <returns>The <see cref="RequestDelegate"/>.</returns>
        public HardwareTestDelegate Build()
        {
            HardwareTestDelegate app = context =>
            {
                return Task.CompletedTask;
            };

            for (var c = _components.Count - 1; c >= 0; c--)
            {
                app = _components[c](app);
            }

            return app;
        }
    }
}
