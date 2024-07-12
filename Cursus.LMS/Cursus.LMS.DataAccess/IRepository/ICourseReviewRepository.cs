using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseReviewRepository
{
    void Update(CourseReview courseReview);
    void UpdateRange(IEnumerable<CourseReview> courseReviews);
}