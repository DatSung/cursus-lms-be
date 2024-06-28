namespace Cursus.LMS.Model.Domain;

public class StateEntity<TD, TA, TS>
{
    public TD? DeactivatedBy { get; set; }
    public DateTime? DeactivatedTime { get; set; }
    public TA? ActivatedBy { get; set; }
    public DateTime? ActivatedTime { get; set; }
    public TS? Status { get; set; }

    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                {
                    return "Activated";
                }
                case 1:
                {
                    return "Deactivated";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}