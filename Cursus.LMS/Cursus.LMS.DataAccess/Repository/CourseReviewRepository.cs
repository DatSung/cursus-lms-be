using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseReviewRepository : Repository<CourseReview>, ICourseReviewRepository
{
    private readonly ApplicationDbContext _context;
    public CourseReviewRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseReview courseReview)
    {
        _context.CourseReviews.Update(courseReview);
    }

    public void UpdateRange(IEnumerable<CourseReview> courseReviews)
    {
        _context.CourseReviews.UpdateRange(courseReviews);

    }
    public async Task<CourseReview> GetById(Guid id)
    {
        return await _context.CourseReviews.FindAsync(id);
    }
}