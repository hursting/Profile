using System.ComponentModel.DataAnnotations;

namespace Profile.Api.V1.Model;

public class CreateBookRequest
{
    [Required]
    [Display(Name = "Book Title")]
    public string Title { get; set; }
    [Required]
    [Display(Name = "Book Author")]
    public string Author { get; set; }
    
    [Required]
    [Display(Name = "Number of Pages")]
    public int Pages { get; set; }
    [Required]
    public Genre Genre { get; set; }
    
    [Required]
    [Display(Name = "Book Description")]
    public string Description { get; set; }

    [Required]
    [Display(Name = "Publication Date")]
    public DateTime PublicationDate { get; set; }
    
    
}