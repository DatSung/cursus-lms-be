using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

public interface IInstructorRatingRepository : IRepository<InstructorRating>
{
    void Update(InstructorRating instructorRating);
    void UpdateRange(IEnumerable<InstructorRating> instructorRatings);
}