namespace LibraryProject.Infrastructure.Data;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<LibraryProjectContext>(options => options.UseSqlServer(Configuration.ConnectionString));
    }
}