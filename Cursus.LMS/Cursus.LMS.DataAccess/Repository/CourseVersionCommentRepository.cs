﻿using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseVersionCommentRepository : Repository<CourseVersionComment>, ICourseVersionCommentRepository
{
    private readonly ApplicationDbContext _context;
    
    public CourseVersionCommentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseVersionComment courseVersionComment)
    {
        _context.CourseVersionComments.Update(courseVersionComment);
    }

    public void UpdateRange(IEnumerable<CourseVersionComment> courseVersionComments)
    {
        _context.CourseVersionComments.UpdateRange(courseVersionComments);
    }
}