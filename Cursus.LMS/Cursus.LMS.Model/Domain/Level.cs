using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.Domain;

public class Level
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
}