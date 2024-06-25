namespace Cursus.LMS.Model.Domain;

public class BaseEntity<CID, UID, SID>
{
    public CID? CreateBy { get; set; }
    public DateTime? CreateTime { get; set; }
    public UID? UpdateBy { get; set; }
    public DateTime? UpdateTime { get; set; }
    public SID? Status { get; set; }
}