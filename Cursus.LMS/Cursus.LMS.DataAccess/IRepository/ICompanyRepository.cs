using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICompanyRepository : IRepository<Company>
{
    void Update(Company company);
    void UpdateRange(IEnumerable<Company> companies);
}