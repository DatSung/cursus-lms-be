using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class InstructorRating : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    [ForeignKey("InstructorId")] public Instructor? Instructor { get; set; }
    public int Rate { get; set; }
}