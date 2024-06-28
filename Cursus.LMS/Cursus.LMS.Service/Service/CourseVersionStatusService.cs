﻿using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CourseVersionStatusService : ICourseVersionStatusService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseVersionStatusService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ResponseDTO> GetCourseVersionsStatus
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetCourseVersionStatus(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateCourseVersionStatus(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }
}