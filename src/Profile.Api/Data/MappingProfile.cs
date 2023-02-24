using Profile.Api.V1.Model;

namespace Profile.Api;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProfileRequest, ProfileDto>();
    }
    
}