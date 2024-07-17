namespace Cursus.LMS.Model.DTO;

public class UpSertBalanceDTO
{
    public string UserId { get; set; }

    public int AvailableBalance { get; set; }

    public int PendingBalance { get; set; }

    public string Currency { get; set; }
}