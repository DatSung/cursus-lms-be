namespace Cursus.LMS.Model.Domain;

public class Privacy
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime LastUpdated { get; set; }
    public bool IsActive { get; set; }
}