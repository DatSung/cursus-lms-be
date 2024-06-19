using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Category : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    [ForeignKey("ParentId")] public Category ParentCategory { get; set; }
    [NotMapped] public List<Category> SubCategories { get; set; } = new List<Category>();
}