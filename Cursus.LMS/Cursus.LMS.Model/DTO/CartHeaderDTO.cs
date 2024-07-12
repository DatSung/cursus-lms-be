using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Model.Domain;

public class CartHeaderDTO
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public double TotalPrice { get; set; }

    public virtual IEnumerable<CartDetailsDTO> CartDetailsDtos { get; set; }
}