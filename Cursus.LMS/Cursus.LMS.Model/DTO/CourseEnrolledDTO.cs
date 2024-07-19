using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class CourseEnrolledDTO
{
    public string CourseName { get; set; }
    public string CourseImage { get; set; }
    public float CourseRate { get; set; }
    public string CourseSummary { get; set; }
    public string Category { get; set; }
    //public Guid? IntructorId { get; set; }
    public string InstructorName { get; set; }
    public string YourProgress { get; set; }
    public Instructor? Instructor { get; set; }
}