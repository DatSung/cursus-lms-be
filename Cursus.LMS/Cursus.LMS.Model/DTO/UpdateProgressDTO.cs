namespace Cursus.LMS.Model.DTO;

public class UpdateProgressDTO
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
    public Guid DetailsId { get; set; }
}