namespace Cursus.LMS.Model.Domain;

public class StateEntity<TD, TA, TC, TM, TS>
{
    public TD? DeactivatedBy { get; set; }
    public DateTime? DeactivatedTime { get; set; }
    public TA? ActivatedBy { get; set; }
    public DateTime? ActivatedTime { get; set; }
    public TC? CreatedBy { get; set; }
    public DateTime? CreatedTime { get; set; }
    public TM? MergedBy { get; set; }
    public DateTime? MergedTime { get; set; }
    public TS? Status { get; set; }

    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                {
                    return "Pending";
                }
                case 1:
                {
                    return "Activated";
                }
                case 2:
                {
                    return "Deactivated";
                }
                default:
                {
                    return "Pending";
                }
            }
        }
    }
}