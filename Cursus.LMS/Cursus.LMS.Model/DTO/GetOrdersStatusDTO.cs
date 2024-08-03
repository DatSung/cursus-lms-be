namespace Cursus.LMS.Model.DTO;

public class GetOrdersStatusDTO
{
    public Guid Id { get; set; }
    public int Status { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }

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