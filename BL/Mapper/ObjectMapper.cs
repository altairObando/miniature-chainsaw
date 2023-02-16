using AutoMapper;

namespace BL.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new((() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => (p.GetMethod?.IsPublic ?? false) || (p.GetMethod?.IsAssembly ?? false);
                cfg.AddProfile<CustomDtoMapper>();
            });
            return config.CreateMapper();
        }));
        public static IMapper Mapper => Lazy.Value;
    }
}
