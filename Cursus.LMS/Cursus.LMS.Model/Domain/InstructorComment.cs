using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cursus.LMS.Model.Domain;

public class InstructorComment : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    [ForeignKey("InstructorId")] public Instructor? Instructor { get; set; }
    public string Comment { get; set; }
}