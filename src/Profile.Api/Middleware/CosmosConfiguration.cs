using Microsoft.Azure.Cosmos;
using Profile.Api.Data;

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
    
    public static IServiceCollection AddQueueClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IQueueClientFactory>(ctx =>
        {
            string connectionString = configuration.GetValue<string>("AzureStorageQueue:ConnectionString");

            return new QueueClientFactory(connectionString);
        });

        return services;
    }
}