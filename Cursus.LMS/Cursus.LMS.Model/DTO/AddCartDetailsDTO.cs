using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class AddCartDetailsDTO
{
    [Required] public Guid CourseId { get; set; }
}