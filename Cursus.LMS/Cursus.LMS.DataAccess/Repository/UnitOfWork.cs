﻿using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace Cursus.LMS.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IStudentRepository StudentRepository { get; set; }
    public IInstructorRepository InstructorRepository { get; set; }
    public ICategoryRepository CategoryRepository { get; }
    public IEmailTemplateRepository EmailTemplateRepository { get; }
    public IUserManagerRepository UserManagerRepository { get; }
    public IPaymentCardRepository PaymentCardRepository { get; set; }

    public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        StudentRepository = new StudentRepository(_context);
        InstructorRepository = new InstructorRepository(_context);
        PaymentCardRepository = new PaymentCardRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        EmailTemplateRepository = new EmailTemplateRepository(_context);
        UserManagerRepository = new UserManagerRepository(userManager);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}