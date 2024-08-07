using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class CourseByStudentDTO : BaseEntity<string, string, int>
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseVersionId { get; set; }
    public string CertificateImgUrl { get; set; }
    public string InstructorName { get; set; }
    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                {
                    return "Pending";
                }
                case 1:
                {
                    return "Enrolled";
                }
                case 2:
                {
                    return "Learning";
                }
                case 3:
                {
                    return "Completed";
                }
                case 4:
                {
                    return "Canceled";
                }
                default:
                {
                    return "Pending";
                }
            }
        }
    }
}