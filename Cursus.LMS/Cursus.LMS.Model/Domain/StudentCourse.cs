using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Cursus.LMS.Model.Domain;

public class StudentCourse : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    [ForeignKey("StudentId")] public virtual Student? Student { get; set; }

    public Guid CourseId { get; set; }
    [ForeignKey("CourseId")] public virtual Course? Course { get; set; }
    
    public string? CertificateImgUrl { get; set; }
}