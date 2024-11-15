﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ASPNET_MVC.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Title { get; set; }

    public int Credits { get; set; }

    public int DepartmentId { get; set; }

    public string Description { get; set; }

    public string Slug { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Person> Instructors { get; set; } = new List<Person>();
}