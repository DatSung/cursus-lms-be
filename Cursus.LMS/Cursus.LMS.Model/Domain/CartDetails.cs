using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CartDetails
{
    [Key] public Guid Id { get; set; }

    public Guid CartHeaderId { get; set; }
    [ForeignKey("CartHeaderId")] public virtual CartHeader CartHeader { get; set; }

    public Guid CourseId { get; set; }
    public string? CourseTitle { get; set; }
    public double CoursePrice { get; set; }
}