using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class SectionDetailsVersionStatus
{
    [Key] public Guid Id { get; set; }
    public Guid? SectionDetailsVersionId { get; set; }
    [ForeignKey("SectionDetailsVersionId")] public SectionDetailsVersion? SectionDetailsVersion { get; set; }
    public int Status { get; set; }
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;

    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                {
                    return "New";
                }
                case 1:
                {
                    return "Submitted";
                }
                case 2:
                {
                    return "Re-Submitted";
                }
                case 3:
                {
                    return "Pending";
                }
                case 4:
                {
                    return "Accepted";
                }
                case 5:
                {
                    return "Rejected";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}