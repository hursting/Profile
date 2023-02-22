using Azure.Storage.Queues;
using Ardalis.GuardClauses;
namespace Profile.Api.Data;

public class QueueClientFactory : IQueueClientFactory
{
    private readonly string _connectionString;

    public QueueClientFactory(string connectionString)
    {
        Guard.Against.NullOrWhiteSpace(connectionString, nameof(connectionString));

        this._connectionString = connectionString;
    }

    public QueueClient Create(string queueName) => new QueueClient(_connectionString, queueName);
}