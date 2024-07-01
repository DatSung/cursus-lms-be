namespace Cursus.LMS.Model.DTO;

public class InstructorTotalCount
{
    public int Total { get; set; }
    public int Pending { get; set; } = 0;
    public int Activated { get; set; } = 0;
    public int Rejected { get; set; } = 0;
    public int Deleted { get; set; } = 0;
}