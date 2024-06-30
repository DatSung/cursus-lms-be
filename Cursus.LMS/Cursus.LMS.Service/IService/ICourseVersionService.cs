﻿using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICourseVersionService
{
    /// <summary>
    /// This method will get all CourseVersion belong to Course.
    /// Base on courseId of the Course
    /// </summary>
    /// <param name="User"></param>
    /// <param name="courseId"></param>
    /// <param name="instructorId"></param>
    /// <param name="filterOn"></param>
    /// <param name="filterQuery"></param>
    /// <param name="sortBy"></param>
    /// <param name="isAscending"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<ResponseDTO> GetCourseVersions
    (
        ClaimsPrincipal User,
        Guid? courseId,
        Guid? instructorId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    /// <summary>
    /// This method 
    /// </summary>
    /// <param name="User"></param>
    /// <param name="courseVersionId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<ResponseDTO> GetCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    );

    Task<ResponseDTO> CreateNewCourseAndCourseVersion
    (
        ClaimsPrincipal User,
        CreateNewCourseAndVersionDTO createNewCourseAndVersionDto
    );
    
    Task<ResponseDTO> CloneNewCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    );

    Task<ResponseDTO> RemoveCourseVersion(ClaimsPrincipal User);
    Task<ResponseDTO> EditCourseVersion(ClaimsPrincipal User);
    Task<ResponseDTO> AcceptCourseVersion(ClaimsPrincipal User);
    Task<ResponseDTO> RejectCourseVersion(ClaimsPrincipal User);

    Task<ResponseDTO> GetCourseVersionsComments
    (
        ClaimsPrincipal User,
        Guid? courseVersionCommentId,
        Guid? courseVersionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        int pageNumber,
        int pageSize
     );
    Task<ResponseDTO> GetCourseVersionComment(ClaimsPrincipal User, Guid courseVersionCommentId);
    Task<ResponseDTO> CreateCourseVersionComment(ClaimsPrincipal User, CreateCourseVersionCommentsDTO createCourseVersionCommentsDTO);
    Task<ResponseDTO> EditCourseVersionComment(ClaimsPrincipal User, EditCourseVersionCommentsDTO editCourseVersionCommentsDTO);
    Task<ResponseDTO> RemoveCourseVersionComment(ClaimsPrincipal User, RemoveCourseVersionCommentDTO removeCourseVersionCommentDTO);
}