using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class AddToCartDTO
{
    [Required] public Guid CourseId { get; set; }
}