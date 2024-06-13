using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Student
{
    [Key]
    public Guid StudentId { get; set; }

    public string UserId { get; set; }  

    [ForeignKey("UserId")]
    public virtual ApplicationUser ApplicationUser { get; set; }

    public string University { get; set; }
    
}