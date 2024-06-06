using Cursus.LMS.DataAccess.IRepository;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IUnitOfWork
{
    IStudentRepository StudentRepository { get; }

    Task SaveAsync();
}