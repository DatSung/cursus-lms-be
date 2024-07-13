namespace Cursus.LMS.Model.Domain;

public class BaseEntity<CID, UID, SID>
{
    public CID? CreatedBy { get; set; }
    public DateTime? CreatedTime { get; set; }
    public UID? UpdatedBy { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public SID? Status { get; set; }
}