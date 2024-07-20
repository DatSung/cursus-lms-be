using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Balance
{
    [Key] public string UserId { get; set; }

    public double TotalBalance { get; set; }
    public double AvailableBalance { get; set; }

    public double PayoutBalance { get; set; }

    public string Currency { get; set; }

    public DateTime UpdatedTime { get; set; }

    [ForeignKey("UserId")] public virtual ApplicationUser ApplicationUser { get; set; }
}