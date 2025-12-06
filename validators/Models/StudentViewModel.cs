using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace validators.Models;

public class StudentViewModel
{
    [Required(ErrorMessage ="Full Name Required")]
    [StringLength(30,MinimumLength =3, ErrorMessage ="Lengenth must be inbetween 3 and 30")]
    [Display(Name="Name")]
    public string FullName { get; set; }

    [Range(18,60,ErrorMessage ="Age must be betwenn 18 and 60")]
    public int Age { get; set; }
    [EmailAddress(ErrorMessage ="Enter Valid mail")]
    public string Email { get; set; }

    [RegularExpression(@"\d{10}$", ErrorMessage ="Enter validNumber 10 digit")]
    public string Mobile { get; set; }

    [Required]
    public string Gender { get; set; }

    [Display(Name="country")]
    public int CountryId { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage ="Password missmatch")]
    [DataType(DataType.Password)]
    public string ComparePassword { get; set; }

}
