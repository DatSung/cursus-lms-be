﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseVersion
{
    [Key] public Guid Id { get; set; }

    public Guid? CourseId { get; set; }
    [ForeignKey("CourseId")] public Course? Course { get; set; }

    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int LearningTime { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double? OldPrice { get; set; }
    public string? CourseImgUrl { get; set; }
    public Guid? InstructorId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? LevelId { get; set; }
    public int? Version { get; set; }
    public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
    public int? CurrentStatus { get; set; }

    [NotMapped] public IEnumerable<CourseSectionVersion>? CourseSectionVersions { get; set; }
}