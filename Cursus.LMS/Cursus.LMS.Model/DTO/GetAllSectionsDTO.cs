namespace Cursus.LMS.Model.DTO;

public class GetAllSectionsDTO
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int CurrentStatus { get; set; }

    public string StatusDescription
    {
        get
        {
            switch (CurrentStatus)
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