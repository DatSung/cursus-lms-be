namespace Cursus.LMS.Model.DTO;

public class AdminCategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    public string? ParentName { get; set; }
    public string CreateBy { get; set; }
    public DateTime CreateTime { get; set; }
    public string UpdateBy { get; set; }
    public DateTime UpdateTime { get; set; }
    public int Status { get; set; }

    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                    return "New";
                case 1:
                    return "Activated";
                case 2:
                    return "Deactivated";
                default:
                    return "Unknown";
            }
        }
    }

    public List<AdminCategoryDTO> SubCategories { get; set; }
}