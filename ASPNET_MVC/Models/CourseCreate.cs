#nullable disable

using ASPNET_MVC.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_MVC.Models;

public partial class CourseCreate : IValidatableObject
{

    [Required]
    [BindRequired]
    [判斷是否有重複的課程名稱]
    [DisplayName("課程名稱")]
    public string Title { get; set; }

    [Required]
    [BindRequired]
    [Range(1, 5, ErrorMessage = "請填入1-5的數字")]
    [DisplayName("課程評價")]
    public int Credits { get; set; }

    public DateTime StartDate { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.Title.Contains("test") && this.Credits < 3)
        {
            yield return new ValidationResult("測試時評價不得小於3" , new string[] { nameof(Title) });
        }
    }
}