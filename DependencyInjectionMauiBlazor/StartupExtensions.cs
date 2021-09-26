using System;

namespace DependencyInjectionMauiBlazor
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Registers the service provider for the services and pages resolver
        /// </summary>
        public static void UseResolver(this IServiceProvider sp)
        {
            Resolver.RegisterServiceProvider(sp);
        }
    }
}