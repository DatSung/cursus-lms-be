﻿using System.Security.Claims;
using Cursus.LMS.DataAccess.Repository;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICourseVersionStatusService
{
    Task<ResponseDTO> GetCourseVersionsStatus
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetCourseVersionStatus(ClaimsPrincipal User);
    Task<ResponseDTO> CreateCourseVersionStatus(ClaimsPrincipal User);
}