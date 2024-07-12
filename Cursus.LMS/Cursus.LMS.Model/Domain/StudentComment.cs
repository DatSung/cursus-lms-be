using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class StudentComment : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    [ForeignKey("StudentId")] public Student? Student { get; set; }
    public string Comment { get; set; }
}