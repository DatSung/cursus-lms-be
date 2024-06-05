using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class PaymentCard
{
    [Key] public string CardNumber { get; set; }
    public string CardName { get; set; }
    public string CardProvider { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")] public virtual ApplicationUser User { get; set; }
}