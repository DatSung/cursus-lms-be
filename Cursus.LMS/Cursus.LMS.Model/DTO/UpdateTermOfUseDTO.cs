namespace Cursus.LMS.Model.DTO;

public class UpdateTermOfUseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsActive { get; set; }
}