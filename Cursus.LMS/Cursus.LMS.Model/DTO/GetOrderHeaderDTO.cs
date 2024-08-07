namespace Cursus.LMS.Model.DTO;

public class GetOrderHeaderDTO
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public double OrderPrice { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? StripeSessionId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedTime { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public int? Status { get; set; }
    public IEnumerable<GetOrderDetailsDTO>? GetOrderDetails { get; set; }
    public string StatusDescription
    {
        get
        {
            return Status switch
            {
                0 => "Pending",
                1 => "Paid",
                2 => "Confirmed",
                3 => "Rejected",
                4 => "PendingRefund",
                5 => "ConfirmedRefund",
                6 => "RejectedRefund",
                _ => "Pending"
            };
        }
    }
}