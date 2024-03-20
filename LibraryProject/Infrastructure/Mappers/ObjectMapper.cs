namespace LibraryProject.Infrastructure.Mappers;

public static class ObjectMapper
{
    private static readonly Lazy<IMapper> LazyMapper = new(() =>
    {
        MapperConfiguration mapperConfiguration = new(configuration =>
        {
            configuration.AddProfile<MapProfile>();
        });

        return mapperConfiguration.CreateMapper();
    });

    public static IMapper Mapper => LazyMapper.Value;
}