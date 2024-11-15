#nullable disable
using System;
using System.Collections.Generic;

namespace ASPNET_MVC.Models;

public partial class CourseList
{
    public string Title { get; set; }

    public int Credits { get; set; }

    public string Description { get; set; }

    public string Slug { get; set; }

}