using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Model.DTO;

public class CreateTransactionDTO
{
    public string UserId { get; set; }

    public StaticEnum.TransactionType Type { get; set; }

    public double Amount { get; set; }
}