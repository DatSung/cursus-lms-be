// using Cursus.LMS.DataAccess.Context;
// using Cursus.LMS.DataAccess.IRepository;
// using Cursus.LMS.Model.Domain;
//
// namespace Cursus.LMS.DataAccess.Repository;
//
// public class CourseSectionVersionStatusRepository : Repository<CourseSectionVersionStatus>,
//     ICourseSectionVersionStatusRepository
// {
//     private readonly ApplicationDbContext _context;
//
//     public CourseSectionVersionStatusRepository(ApplicationDbContext context) : base(context)
//     {
//         _context = context;
//     }
//
//     public void Update(CourseSectionVersionStatus courseSectionVersionStatus)
//     {
//         _context.CourseSectionVersionStatus.Update(courseSectionVersionStatus);
//     }
//
//     public void UpdateRange(IEnumerable<CourseSectionVersionStatus> courseSectionVersionsStatus)
//     {
//         _context.CourseSectionVersionStatus.UpdateRange(courseSectionVersionsStatus);
//     }
// }