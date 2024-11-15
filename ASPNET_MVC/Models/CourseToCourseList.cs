#nullable disable
using System;
using System.Collections.Generic;

namespace ASPNET_MVC.Models;

/// <summary>
/// 隱含轉換擴充 Course -> CourseList
/// </summary>
public partial class Course
{ 
    public static implicit operator CourseList(Course course)
    {
        return new CourseList
        {
            Credits = course.Credits,
            Description = course.Description,
            Title = course.Title,
            Slug = course.Slug,
        };
    }
}