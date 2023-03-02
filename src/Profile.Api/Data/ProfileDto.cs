using Profile.Api.V1.Model;

namespace Profile.Api;

public class ProfileDto
{
    public string Id { get; set; }
    
    public string Title { get; set; }
    
    public string Surname { get; set; }
    
    public string Firstname { get; set; }
    
    public string Gender { get; set; }
    
    public string Occupation { get; set; }
    
}