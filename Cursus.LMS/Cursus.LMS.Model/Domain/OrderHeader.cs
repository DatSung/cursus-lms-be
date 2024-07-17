using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class OrderHeader : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    [ForeignKey("StudentId")] public virtual Student Student { get; set; }
    public double OrderPrice { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? StripeSessionId { get; set; }
    [NotMapped] public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }
}