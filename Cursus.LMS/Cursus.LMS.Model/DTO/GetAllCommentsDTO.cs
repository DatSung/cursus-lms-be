namespace Cursus.LMS.Model.DTO;

public class GetAllCommentsDTO
{
    public Guid? Id { get; set; }
    public string? Comment { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? CreateBy { get; set; }
    public DateTime? UpdateTime { get; set; }
    public string? UpdateBy { get; set; }
    public int Status { get; set; }

    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                {
                    return "New";
                }
                case 1:
                {
                    return "Edited";
                }
                case 2:
                {
                    return "Deleted";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}