using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CartHeader
{
    [Key] public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    [ForeignKey("StudentId")] public virtual Student Student { get; set; }

    public double TotalPrice { get; set; }

    [NotMapped] public virtual IEnumerable<CartDetails> CartDetails { get; set; }
}