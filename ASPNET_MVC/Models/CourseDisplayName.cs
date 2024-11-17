#nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_MVC.Models;

[ModelMetadataType<CourseMetadata>()]
public partial class Course { }

public class CourseMetadata
{
    public int CourseId { get; set; }

    [DisplayName("課程標題")]
    public string Title { get; set; }

    [DisplayName("課程評分")]
    [UIHint(nameof(Credits))]   
    public int Credits { get; set; }

    [DisplayName("課程名稱")]
    public int DepartmentId { get; set; }

    [DisplayName("課程描述")]
    public string Description { get; set; }

    public string Slug { get; set; }

    public bool IsDeleted { get; set; }

    [DisplayName("開始日期")]
    public DateTime StartDate { get; set; }
}
