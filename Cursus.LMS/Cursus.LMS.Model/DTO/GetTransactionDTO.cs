using System.ComponentModel.DataAnnotations.Schema;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Model.DTO;

public class GetTransactionDTO
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public StaticEnum.TransactionType Type { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedTime { get; set; }

    public string TypeDescription
    {
        get
        {
            switch (Type)
            {
                case StaticEnum.TransactionType.Purchase:
                {
                    return "Purchase";
                }
                case StaticEnum.TransactionType.Income:
                {
                    return "Income";
                }
                case StaticEnum.TransactionType.Payout:
                {
                    return "Payout";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}