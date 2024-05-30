using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Cursus.LMS.Model.Domain;

public class StudentCourse
{
    [Key]
    public Guid Id { get; set; }

    public Guid? StudentId { get; set; }
    [ForeignKey("StudentId")]
    public virtual Student Student { get; set; }
    
    public Guid? CourseId { get; set; }
    [ForeignKey("CourseId")]
    public virtual Course Course { get; set; }

    public DateTime LearningTime { get; set; }
    public DateTime StartAt { get; set; } = DateTime.Now;
    public DateTime EndAt { get; set; }
    public string CertificateImgUrl { get; set; }

    public bool IsSuccess { get; set; }
    public bool IsExpelled { get; set; }
}