using System;
using AutoMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Moq;
using Profile.Api.V1.Controllers;
using Xunit;

namespace Profile.Api.Tests;

public class ProfileControllerTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IConfiguration> _configuration;
    
    public ProfileControllerTest()
    {
        _mapper = new Mock<IMapper>();

        _configuration = new Mock<IConfiguration>();
    }
    
    [Fact]
    public void client_notspecified_throws_exception()
    {
        Assert.Throws<ArgumentNullException>(() => new ProfileController(null,_mapper.Object,_configuration.Object));
    }
    
    [Fact]
    public void mapper_notspecified_throws_exception()
    {
        var mockCosmosClient = new Mock<CosmosClient>();
        Assert.Throws<ArgumentNullException>(() => new ProfileController(mockCosmosClient.Object,null,_configuration.Object));
    }
}