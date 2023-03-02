using System.ComponentModel.DataAnnotations;

namespace Profile.Api.V1.Model;

public class CreateProfileRequest
{
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required]
    [Display(Name = "Lastname")]
    public string Surname { get; set; }
    
    [Required]
    [Display(Name = "Firstname")]
    public string Firstname { get; set; }
    
    [Required]
    [Display(Name = "Age")]
    public int Age { get; set; }

    [Display(Name = "Gender")]
    public string Sex { get; set; }
    
    [Required]
    [Display(Name = "Occupation")]
    public string Occupation { get; set; }

   
    
    
}