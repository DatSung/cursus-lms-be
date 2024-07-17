namespace Cursus.LMS.Model.DTO;

public class UpsertBalanceDTO
{
    public string UserId { get; set; }

    public double AvailableBalance { get; set; }

    public double PendingBalance { get; set; }

    public string Currency { get; set; }
}