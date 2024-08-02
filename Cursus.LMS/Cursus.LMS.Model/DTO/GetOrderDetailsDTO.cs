namespace Cursus.LMS.Model.DTO;

public class GetOrderDetailsDTO
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string? CourseTitle { get; set; }
    public double CoursePrice { get; set; }
    public Guid OrderHeaderId { get; set; }
}