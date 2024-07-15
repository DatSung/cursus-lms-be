using Cursus.LMS.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.DataAccess.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Update(Course course);
        void UpdateRange(IEnumerable<Course> courses);
        Task<Course?> GetById(Guid courseId);
    }
}
