namespace Cursus.LMS.Model.DTO;

public class CartDetailsDTO
{
    public Guid Id { get; set; }

    public Guid CartHeaderId { get; set; }

    public Guid CourseId { get; set; }

    public double CoursePrice { get; set; }
    
    public string? CourseTitle { get; set; }
}