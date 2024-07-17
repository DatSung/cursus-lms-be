using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Balance
{
    [Key] public Guid InstructorId { get; set; }

    public int AvailableBalance { get; set; }

    public int PendingBalance { get; set; }

    public string Currency { get; set; }

    public DateTime UpdatedTime { get; set; }

    [ForeignKey("InstructorId")] public virtual Instructor? Instructor { get; set; }
}