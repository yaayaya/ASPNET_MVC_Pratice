using ASPNET_MVC.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_MVC.ValidationAttributes;

public class 判斷是否有重複的課程名稱Attribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string? title = value as string;

        if (title.IsNullOrEmpty())
        {
            return ValidationResult.Success;
        }


        var db = (ContosoUniversityContext)validationContext.GetService(typeof(ContosoUniversityContext))!;

        bool exists = db.Courses.Any(c => c.Title == title);

        if (!exists)
        {
            return ValidationResult.Success;
        }
        else
        {
            /// Member = 當前驗證對象
            var filedName = validationContext.MemberName ?? "";
            return new ValidationResult("課程名稱已重複", new string[] { filedName });

        }
    }
}
