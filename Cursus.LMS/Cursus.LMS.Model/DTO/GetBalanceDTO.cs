namespace Cursus.LMS.Model.DTO;

public class GetBalanceDTO
{
    public double TotalBalance { get; set; }
    public double AvailableBalance { get; set; }
    public double PayoutBalance { get; set; }
    public string Currency { get; set; }
}