using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class CreateCategoryDTO 
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ParentId { get; set; } = null;
}