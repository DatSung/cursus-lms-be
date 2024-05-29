using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class OrderHeader
{
    [Key] public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    [ForeignKey("StudentId")] public virtual Student Student { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public double OrderPrice { get; set; }

    public bool IsPayout { get; set; }
    public bool IsSuccess { get; set; }

    [NotMapped] public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }
}