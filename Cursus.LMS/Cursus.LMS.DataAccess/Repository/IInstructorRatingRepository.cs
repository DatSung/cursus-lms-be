﻿using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.DataAccess.Repository;
using Cursus.LMS.Model.Domain;

public class InstructorRatingRepository : Repository<InstructorRating>, IInstructorRatingRepository
{
    private readonly ApplicationDbContext _context;

    public InstructorRatingRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

}