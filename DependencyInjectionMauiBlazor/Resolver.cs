using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionMauiBlazor
{
    public static class Resolver
    {
        private static IServiceProvider? _serviceProvider;
        public static IServiceProvider ServiceProvider => _serviceProvider ?? throw new Exception("Service provider has not been initialized");

        /// <summary>
        /// Register the service provider
        /// </summary>
        public static void RegisterServiceProvider(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }
        /// <summary>
        /// Get service of type <typeparamref name="T"/> from the service provider.
        /// </summary>
        public static T Resolve<T>() where T : class
            => ServiceProvider.GetRequiredService<T>();

        /// <summary>
        /// Returns a resolved instance of the requested type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ResolveScope<T>() where T : class
            => Scope.ServiceProvider.GetRequiredService<T>();

        private static IServiceScope? _scope;
        public static IServiceScope Scope => _scope ??= ServiceProvider.CreateScope();

        public static IServiceScope NewScope => ServiceProvider.CreateScope();
    }
}