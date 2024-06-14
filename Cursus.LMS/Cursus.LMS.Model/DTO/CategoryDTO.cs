namespace Cursus.LMS.Model.DTO;

public class CategoryDTO
{
    public string Name { get; set; }
    public CategoryDTO SubCategory { get; set; }
}