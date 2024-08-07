using System.Text.Json.Serialization;

namespace Cursus.LMS.Model.DTO;

public class EnrollCourseDTO
{
    [JsonIgnore]
    public Guid studentId { get; set; }
    public Guid courseId { get; set; }
}