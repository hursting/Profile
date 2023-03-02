using AutoMapper;
using Microsoft.Azure.Cosmos;

namespace Profile.Api.Middleware;

public static class CosmosConfiguration
{
    public static IServiceCollection AddCosmosClient(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSingleton(ctx =>
        {
            string serviceEndpoint = configuration.GetValue<string>("CosmosDb:ServiceEndpoint");
            string authKey = configuration.GetValue<string>("CosmosDb:AuthKey");

            return new CosmosClient(serviceEndpoint, authKey, new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions
                {
                    IgnoreNullValues = false,
                    Indented = false,
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                }
            });
        });
    
    public static IServiceCollection AddAutoMapper(this IServiceCollection services, IConfiguration configuration)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
   
}