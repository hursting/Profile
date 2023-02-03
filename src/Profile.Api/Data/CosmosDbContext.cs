using Microsoft.Azure.Cosmos;

namespace Profile.Api;

public class CosmosDbContext
{
    private readonly CosmosClient _cosmosClient;
    private readonly Database _database;
    private readonly Container _container;

    public CosmosDbContext(string endpoint, string key, string databaseName, string containerName)
    {
        _cosmosClient = new CosmosClient(endpoint, key);
        _database = _cosmosClient.GetDatabase(databaseName);
        _container = _database.GetContainer(containerName);
    }

    public Container Container => _container;
}