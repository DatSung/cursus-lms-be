using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.Domain;

public class Category
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
}