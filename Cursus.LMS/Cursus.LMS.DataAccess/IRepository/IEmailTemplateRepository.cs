using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IEmailTemplateRepository : IRepository<EmailTemplate>
{
    void Update(EmailTemplate emailTemplate);
}