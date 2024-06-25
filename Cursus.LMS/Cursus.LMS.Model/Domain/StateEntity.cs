namespace Cursus.LMS.Model.Domain;

public class StateEntity<C, U, D, R, S>
{
    public C? CreatedBy { get; set; }
    public DateTime? CreatedTime { get; set; }
    public U? UpdatedBy { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public D? DeletedBy { get; set; }
    public DateTime? DeletedTime { get; set; }
    public R? RejectedBy { get; set; }
    public DateTime? RejectedTime { get; set; }
    public S? Status { get; set; }
}