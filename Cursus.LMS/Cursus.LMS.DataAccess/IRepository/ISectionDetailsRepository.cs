using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ISectionDetailsRepository : IRepository<SectionDetails>
{
    void Update(SectionDetails sectionDetails);
    void UpdateRange(IEnumerable<SectionDetails> sectionsDetails);
}