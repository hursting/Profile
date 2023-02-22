using Ardalis.GuardClauses;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Profile.Api.Controllers;
using Profile.Api.Data;
using Profile.Api.V1.Model;

namespace Profile.Api.V1.Controllers;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("[controller]")]
public class ProfileController : BaseApiController
{

    private readonly CosmosClient _cosmosClient;

    private readonly IQueueClientFactory _clientFactory;
    
    private readonly QueueClient _queueClient;
    
    
    public ProfileController(CosmosClient client, IQueueClientFactory clientFactory)
    {
        Guard.Against.Null(client, nameof(client));
        
        _cosmosClient = client;

        _queueClient = clientFactory.Create("somename");
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookRequest request, CancellationToken token)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var container = _cosmosClient.GetContainer("asdfasdf", "asdfasdf");

        var item = container.CreateItemAsync(request, cancellationToken: token);
        
        return CreatedAtAction("Get", null, request);
    }
    
    
    
    
}