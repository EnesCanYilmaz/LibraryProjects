namespace LibraryProject.App.IOC;

internal static class ServiceCollectionContainerBuilderExtensions
{
    /// <summary>
    /// Dependency injection for services layer scoped services type
    /// </summary>
    /// <param name="services">type of IServiceCollection</param>
    /// <returns>type of IServiceCollection</returns>
    internal static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<IFileService, FileManager>();
        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}