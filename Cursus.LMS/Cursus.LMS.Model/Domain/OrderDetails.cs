using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class OrderDetails
{
    [Key] public Guid Id { get; set; }

    public Guid CourseId { get; set; }
    public string? CourseTitle { get; set; }
    public double CoursePrice { get; set; }

    public Guid OrderHeaderId { get; set; }
    [ForeignKey("OrderHeaderId")] public virtual OrderHeader OrderHeader { get; set; }
}