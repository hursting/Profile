using Azure.Storage.Queues;

namespace Profile.Api.Data;

public interface IQueueClientFactory
{
    QueueClient Create(string queueName);
}