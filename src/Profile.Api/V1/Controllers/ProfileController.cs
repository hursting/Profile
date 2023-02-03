using Microsoft.AspNetCore.Mvc;
using Profile.Api.Controllers;

namespace Profile.Api.V1.Controllers;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("[controller]")]
public class ProfileController : BaseApiController
{
    public ProfileController()
    {
        
    }
}