using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class CreateCategoryDTO : BaseEntity<string, string , int>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }

}