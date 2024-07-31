using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IPrivacyRepository : IRepository<Privacy>
{
    void Update(Privacy privacy);
    void UpdateRange(IEnumerable<Privacy> privacies);
}