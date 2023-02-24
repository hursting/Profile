using System.Net;
using Ardalis.GuardClauses;
using AutoMapper;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Profile.Api.Controllers;
using Profile.Api.V1.Model;

namespace Profile.Api.V1.Controllers;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("[controller]")]
public class ProfileController : BaseApiController
{

    private readonly CosmosClient _cosmosClient;
    
    private readonly QueueClient _queueClient;

    private readonly IConfiguration _configuration;

    private readonly IMapper _mapper;
    
    
    public ProfileController(CosmosClient client, IMapper mapper, IConfiguration configuration)
    {
        Guard.Against.Null(client, nameof(client));
        Guard.Against.Null(mapper, nameof(mapper));
        Guard.Against.Null(configuration, nameof(configuration));
        _mapper = mapper;
        _cosmosClient = client;
        _configuration = configuration;

    }
    
    [HttpPost]
    public async Task<HttpStatusCode> Create([FromBody] CreateProfileRequest request, CancellationToken token)
    {

        Guard.Against.Null(request, nameof(request));
        
        if (!ModelState.IsValid)
        {
            return HttpStatusCode.BadRequest;
        }

        ProfileDto profileDto = _mapper.Map<ProfileDto>(request);
        
        string databaseId=  _configuration.GetValue<string>("CosmosDb:DatabaseId");
        
        string containerId=  _configuration.GetValue<string>("CosmosDb:ContainerId");

        var container = _cosmosClient.GetContainer(databaseId, containerId);

        try
        {
            var item = container.CreateItemAsync(profileDto, cancellationToken: token);
            return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            return HttpStatusCode.InternalServerError;
        }
    }
    
    
    
    
}