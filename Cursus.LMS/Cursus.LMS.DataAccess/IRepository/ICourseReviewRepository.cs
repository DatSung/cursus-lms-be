using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseReviewRepository : IRepository<CourseReview>
{
    void Update(CourseReview courseReview);
    void UpdateRange(IEnumerable<CourseReview> courseReviews);
    Task<CourseReview> GetById(Guid id);
}