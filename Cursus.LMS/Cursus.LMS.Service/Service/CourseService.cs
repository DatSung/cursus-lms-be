using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Hangfire;

namespace Cursus.LMS.Service.Service;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStudentCourseService _studentCourseService;
    private readonly ICourseProgressService _courseProgressService;

    public CourseService
    (
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IStudentCourseService studentCourseService, ICourseProgressService courseProgressService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _studentCourseService = studentCourseService;
        _courseProgressService = courseProgressService;
    }

    public async Task<ResponseDTO> CreateFrameCourse(ClaimsPrincipal User, Guid courseVersionId)
    {
        try
        {
            // Get instructorId by userId
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var instructor = await _unitOfWork.InstructorRepository.GetAsync
            (
                filter: x => x.UserId == userId,
                includeProperties: "ApplicationUser"
            );

            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor does not exist",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (instructor.IsAccepted == false)
            {
                return new ResponseDTO()
                {
                    Message = "Permission to create course was not found",
                    IsSuccess = false,
                    StatusCode = 403,
                    Result = null
                };
            }

            // Create an empty course
            var course = new Course()
            {
                Id = Guid.NewGuid(),
                Code = null,
                InstructorId = instructor?.InstructorId,
                CourseVersionId = courseVersionId,
                Status = 0,
                Version = 1,
                TotalStudent = 0,
                TotalRate = 0,
                ActivatedBy = null,
                DeactivatedBy = null,
                ActivatedTime = null,
                DeactivatedTime = null,
                MergedTime = null,
                MergedBy = null,
                CreatedBy = instructor?.ApplicationUser.Email,
                CreatedTime = DateTime.UtcNow
            };

            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Create empty course successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = course
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = true
            };
        }
    }

    public async Task<ResponseDTO> GetCourses
    (
        ClaimsPrincipal User,
        Guid? instructorId,
        string? filterOn,
        string? filterQuery,
        double? fromPrice,
        double? toPrice,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 1,
        int pageSize = 5
    )
    {
        try
        {
            var courses = new List<Course>();

            var userRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(instructorId.ToString()))
            {
                if (userRole is null || userRole.Contains(StaticUserRoles.Student))
                {
                    courses = _unitOfWork.CourseRepository
                        .GetAllAsync
                        (
                            filter: x => x.Status == 1
                        )
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }

                if (userRole != null && userRole.Contains(StaticUserRoles.Instructor))
                {
                    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                    instructorId = _unitOfWork.InstructorRepository
                        .GetAsync(x => x.UserId == userId)
                        .GetAwaiter()
                        .GetResult()!
                        .InstructorId;

                    courses = _unitOfWork.CourseRepository
                        .GetAllAsync
                        (
                            filter: x => x.InstructorId == instructorId
                        )
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }

                if (userRole != null && userRole.Contains(StaticUserRoles.Admin))
                {
                    courses = _unitOfWork.CourseRepository
                        .GetAllAsync()
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }
            }
            else
            {
                if (userRole is null || userRole.Contains(StaticUserRoles.Student))
                {
                    courses = _unitOfWork.CourseRepository
                        .GetAllAsync
                        (
                            filter: x => x.Status == 1 && x.InstructorId == instructorId
                        )
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }

                if (userRole != null && userRole.Contains(StaticUserRoles.Instructor))
                {
                    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                    instructorId = _unitOfWork.InstructorRepository
                        .GetAsync(x => x.UserId == userId)
                        .GetAwaiter()
                        .GetResult()!
                        .InstructorId;

                    courses = _unitOfWork.CourseRepository
                        .GetAllAsync
                        (
                            filter: x => x.InstructorId == instructorId
                        )
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }

                if (userRole != null && userRole.Contains(StaticUserRoles.Admin))
                {
                    courses = _unitOfWork.CourseRepository
                        .GetAllAsync
                        (
                            filter: x => x.InstructorId == instructorId
                        )
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }
            }

            var courseVersions = new List<CourseVersion>();

            foreach (var course in courses)
            {
                var courseVersion = await _unitOfWork.CourseVersionRepository
                    .GetAsync(
                        filter: x => x.Id == course.CourseVersionId,
                        includeProperties: "Category,Level"
                    );
                if (courseVersion is not null)
                {
                    courseVersions.Add(courseVersion);
                }
            }


            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "title":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Title.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "code":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Code.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "description":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Description.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "category":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Category != null &&
                            x.Category.Name.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "instructor":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Course.Instructor != null &&
                            x.Course.Instructor.ApplicationUser.FullName.Contains(filterQuery,
                                StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "status":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.CurrentStatus == int.Parse(filterQuery.Trim())).ToList();
                        break;
                    }
                }
            }

            // Price range
            if (toPrice is not null && fromPrice is not null)
            {
                if (toPrice >= 0)
                {
                    courseVersions = fromPrice >= toPrice
                        ? courseVersions.Where(x => x.Price >= toPrice && x.Price <= fromPrice).ToList()
                        : courseVersions.Where(x => x.Price >= toPrice).ToList();
                }
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "title":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Title)]
                            : [.. courseVersions.OrderByDescending(x => x.Title)];
                        break;
                    }
                    case "code":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Code)]
                            : [.. courseVersions.OrderByDescending(x => x.Code)];
                        break;
                    }
                    case "description":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Description)]
                            : [.. courseVersions.OrderByDescending(x => x.Description)];
                        break;
                    }
                    case "price":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Price)]
                            : [.. courseVersions.OrderByDescending(x => x.Price)];
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Sort by highest rank (TotalStudent) after all other sorting and filtering
            courseVersions = courseVersions.OrderByDescending(cv => cv.Course.TotalStudent).ToList();

            // Pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                courseVersions = courseVersions.Skip(skipResult).Take(pageSize).ToList();
            }

            var courseVersionDto = _mapper.Map<List<GetCourseDTO>>(courseVersions);

            return new ResponseDTO()
            {
                Result = courseVersionDto,
                Message = "Get courses successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> GetTopPurchasedCourses(
        int? year = null,
        int? month = null,
        int? quarter = null,
        int top = 5,
        int pageNumber = 1,
        int pageSize = 5,
        string? byCategoryName = null
    )
    {
        try
        {
            // Lấy danh sách khóa học ban đầu
            var coursesQuery = _unitOfWork.CourseRepository.GetAllAsync(
                c => c.Status == 1 // Lọc các khóa học có trạng thái hoạt động
            );

            var courses = (await coursesQuery).ToList();

            // Áp dụng bộ lọc theo thời gian
            if (year.HasValue)
            {
                courses = courses
                    .Where(c => c.CreatedTime.HasValue && c.CreatedTime.Value.Year == year.Value)
                    .ToList();
            }

            if (month.HasValue)
            {
                courses = courses
                    .Where(c => c.CreatedTime.HasValue && c.CreatedTime.Value.Month == month.Value)
                    .ToList();
            }

            if (quarter.HasValue)
            {
                int startMonth = (quarter.Value - 1) * 3 + 1;
                int endMonth = startMonth + 2;
                courses = courses
                    .Where(c => c.CreatedTime.HasValue &&
                                c.CreatedTime.Value.Month >= startMonth &&
                                c.CreatedTime.Value.Month <= endMonth)
                    .ToList();
            }

            // Lấy danh sách CourseVersionId từ courses
            var courseVersionIds = courses
                .Select(c => c.CourseVersionId)
                .Distinct()
                .ToList();

            // Lấy các CourseVersion tương ứng
            var courseVersions = (await _unitOfWork.CourseVersionRepository.GetAllAsync(
                cv => courseVersionIds.Contains(cv.Id),
                includeProperties: "Category"
            )).ToList();

            // Áp dụng bộ lọc CategoryName
            if (!string.IsNullOrEmpty(byCategoryName))
            {
                courseVersions = courseVersions
                    .Where(cv => cv.Category != null &&
                                 cv.Category.Name.Contains(byCategoryName, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            // Lọc lại danh sách courses dựa trên CourseVersion
            courses = courses
                .Where(c => courseVersions.Any(cv => cv.Id == c.CourseVersionId))
                .ToList();

            // Sắp xếp danh sách theo số lượng sinh viên giảm dần
            courses = courses.OrderByDescending(c => c.TotalStudent).ToList();

            // Áp dụng phân trang và giới hạn top
            int skip = (pageNumber - 1) * pageSize;
            courses = courses
                .Skip(skip)
                .Take(pageSize > top ? top : pageSize)
                .ToList();

            // Chuyển đổi sang DTO
            var courseDtos = courses.Select(c => new GetTopPurchasedCoursesDTO
            {
                Id = c.Id,
                Title = courseVersions.FirstOrDefault(cv => cv.Id == c.CourseVersionId)?.Title,
                Code = c.Code,
                Description = courseVersions.FirstOrDefault(cv => cv.Id == c.CourseVersionId)?.Description,
                TotalStudent = c.TotalStudent ?? 0,
                CategoryName = courseVersions.FirstOrDefault(cv => cv.Id == c.CourseVersionId)?.Category?.Name
            }).ToList();

            return new ResponseDTO
            {
                Result = courseDtos,
                Message = "Get top purchased courses successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }


    public async Task<ResponseDTO> GetLeastPurchasedCourses(
        int? year = null,
        int? month = null,
        int? quarter = null,
        int top = 5,
        int pageNumber = 1,
        int pageSize = 5,
        string? byCategoryName = null
    )
    {
        try
        {
            // Lấy danh sách khóa học ban đầu
            var coursesQuery = _unitOfWork.CourseRepository.GetAllAsync(
                c => c.Status == 1 // Lọc các khóa học có trạng thái hoạt động
            );

            var courses = (await coursesQuery).ToList();

            // Áp dụng bộ lọc theo thời gian
            if (year.HasValue)
            {
                courses = courses
                    .Where(c => c.CreatedTime.HasValue && c.CreatedTime.Value.Year == year.Value)
                    .ToList();
            }

            if (month.HasValue)
            {
                courses = courses
                    .Where(c => c.CreatedTime.HasValue && c.CreatedTime.Value.Month == month.Value)
                    .ToList();
            }

            if (quarter.HasValue)
            {
                int startMonth = (quarter.Value - 1) * 3 + 1;
                int endMonth = startMonth + 2;
                courses = courses
                    .Where(c => c.CreatedTime.HasValue &&
                                c.CreatedTime.Value.Month >= startMonth &&
                                c.CreatedTime.Value.Month <= endMonth)
                    .ToList();
            }

            // Lấy danh sách CourseVersionId từ courses
            var courseVersionIds = courses
                .Select(c => c.CourseVersionId)
                .Distinct()
                .ToList();

            // Lấy các CourseVersion tương ứng
            var courseVersions = (await _unitOfWork.CourseVersionRepository.GetAllAsync(
                cv => courseVersionIds.Contains(cv.Id),
                includeProperties: "Category"
            )).ToList();

            // Áp dụng bộ lọc CategoryName
            if (!string.IsNullOrEmpty(byCategoryName))
            {
                courseVersions = courseVersions
                    .Where(cv => cv.Category != null &&
                                 cv.Category.Name.Contains(byCategoryName, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            // Lọc lại danh sách courses dựa trên CourseVersion
            courses = courses
                .Where(c => courseVersions.Any(cv => cv.Id == c.CourseVersionId))
                .ToList();

            // Sắp xếp danh sách theo số lượng sinh viên tăng dần
            courses = courses.OrderBy(c => c.TotalStudent).ToList();

            // Áp dụng phân trang và giới hạn top
            int skip = (pageNumber - 1) * pageSize;
            courses = courses
                .Skip(skip)
                .Take(pageSize > top ? top : pageSize)
                .ToList();

            // Chuyển đổi sang DTO
            var courseDtos = courses.Select(c => new GetTopPurchasedCoursesDTO
            {
                Id = c.Id,
                Title = courseVersions.FirstOrDefault(cv => cv.Id == c.CourseVersionId)?.Title,
                Code = c.Code,
                Description = courseVersions.FirstOrDefault(cv => cv.Id == c.CourseVersionId)?.Description,
                TotalStudent = c.TotalStudent ?? 0,
                CategoryName = courseVersions.FirstOrDefault(cv => cv.Id == c.CourseVersionId)?.Category?.Name
            }).ToList();

            return new ResponseDTO
            {
                Result = courseDtos,
                Message = "Get least purchased courses successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }


    public async Task<ResponseDTO> GetCourse(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            var courseVersion = await _unitOfWork.CourseVersionRepository
                .GetAsync
                (
                    filter: x => x.Id == course.CourseVersionId,
                    includeProperties: "Category,Level"
                );

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course have no content"
                };
            }

            var courseVersionDto = _mapper.Map<GetCourseDTO>(courseVersion);

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = courseVersionDto,
                Message = "Get course successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 500,
                Result = null,
                Message = e.Message
            };
        }
    }

    public async Task<ResponseDTO> GetCourseInfo(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            var getCourseInfoDto = _mapper.Map<GetCourseInfoDTO>(course);

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = getCourseInfoDto,
                Message = "Get course information successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> ActivateCourse(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == course.CourseVersionId);

            if (!courseVersion!.CurrentStatus.Equals(StaticCourseVersionStatus.Merged))
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null,
                    Message = "Course was not allow to sell"
                };
            }

            course.Status = StaticCourseStatus.Activated;

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = null,
                Message = "Activated course successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> DeactivateCourse(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            course.Status = StaticCourseStatus.Deactivated;
            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveAsync();

            BackgroundJob.Enqueue<IEmailSender>(job => job.SendDeactivatedCourseEmailForStudents(courseId));

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = null,
                Message = "Deactivated course successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> EnrollCourse(ClaimsPrincipal User, EnrollCourseDTO enrollCourseDto)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var studentId = _unitOfWork.StudentRepository
                .GetAsync(x => x.UserId == userId)
                .GetAwaiter()
                .GetResult()!
                .StudentId;
            enrollCourseDto.studentId = studentId;
            var studentCourse = await _unitOfWork.StudentCourseRepository.GetAsync
            (
                x => x.StudentId == enrollCourseDto.studentId && x.CourseId == enrollCourseDto.courseId
            );

            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == enrollCourseDto.courseId);
            if (course is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (studentCourse is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student was not own this course",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            if (studentCourse.Status != StaticStatus.StudentCourse.Confirmed)
            {
                return new ResponseDTO()
                {
                    Message = "This course was not confirmed by admin",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            await _studentCourseService.UpdateStudentCourse
            (
                User,
                new UpdateStudentCourseDTO()
                {
                    Status = StaticStatus.StudentCourse.Enrolled,
                    CourseId = enrollCourseDto.courseId,
                    StudentId = enrollCourseDto.studentId
                }
            );

            await _courseProgressService.CreateProgress
            (
                new CreateProgressDTO()
                {
                    StudentCourseId = studentCourse.Id
                }
            );

            return new ResponseDTO()
            {
                Message = "Enroll course successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = true
            };
        }
    }

    public async Task<ResponseDTO> SuggestCourse(Guid studentId)
    {
        try
        {
            //kiểm tra Id student có tồn tại không
            var id =
                await _unitOfWork.StudentCourseRepository.GetAsync(i => i.StudentId == studentId);
            if (id == null)
            {
                return new ResponseDTO()
                {
                    Message = "StudentID Invalid",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            //Lấy danh sách các khóa học mà student đã mua
            var courses = await _unitOfWork.StudentCourseRepository.GetAllAsync
                (c => c.StudentId == studentId && c.Status == 0 || c.Status == 1 || c.Status == 3);
            if (courses == null || !courses.Any())
            {
                return new ResponseDTO()
                {
                    Message = "Student has not enrolled in any courses",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }
            var coursesEnroll = courses.Select(c => c.CourseId).Distinct().ToList();

            

            //tạo danh sách gợi ý khóa học
            var suggestCourse = new List<Course>();
            var redFlag = 0;
            // Lấy danh sách gợi ý khóa học trùng CategoryId với các khóa học đã mua của student
            foreach (var course in courses)
            {
                if (redFlag >= 5) break;
                var courseId = course.CourseId;
                var courseVersions = await _unitOfWork.CourseVersionRepository.GetAllAsync(
                    cv => cv.CourseId == courseId,
                    includeProperties: "Category");

                foreach (var courseVersion in courseVersions)
                {
                    var categoryId = courseVersion.CategoryId;

                    // Lấy danh sách các CourseVersion khác cùng CategoryId
                    var relatedCourseVersions = await _unitOfWork.CourseVersionRepository.GetAllAsync(cv =>
                        cv.CategoryId == categoryId && !coursesEnroll.Contains(cv.CourseId));

                    // Lấy danh sách các khóa học từ các CourseVersion này
                    foreach (var relatedCourseVersion in relatedCourseVersions)
                    {
                        var relatedCourse =
                            await _unitOfWork.CourseRepository.GetAsync(c => c.Id == relatedCourseVersion.CourseId);
                        if (relatedCourse != null)
                        {
                            suggestCourse.Add(relatedCourse);
                        }
                    }
                }
            }

            var distinctCourses = suggestCourse.Distinct().ToList();

            return new ResponseDTO()
            {
                Message = "Suggest course successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = distinctCourses
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> UpsertCourseTotal(UpsertCourseTotalDTO upsertCourseTotalDto)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == upsertCourseTotalDto.CourseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (upsertCourseTotalDto.TotalStudent is not null)
            {
                course.TotalStudent += upsertCourseTotalDto.TotalStudent;
            }

            if (upsertCourseTotalDto.TotalEarned is not null)
            {
                course.TotalEarned += upsertCourseTotalDto.TotalEarned;
                course.TotalStudent += 1;
            }

            if (upsertCourseTotalDto.UpdateTotalRate)
            {
                var courseReviews = _unitOfWork.CourseReviewRepository
                    .GetAllAsync(x => x.CourseId == upsertCourseTotalDto.CourseId)
                    .GetAwaiter()
                    .GetResult()
                    .ToList();

                var totalRate = courseReviews.ToList().Sum(x => x.Rate);
                var avgRate = totalRate / courseReviews.Count;

                course.TotalRate = avgRate;
            }

            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Upsert course total successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = course
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> GetAllBookMarkedCoursesById(Guid studentId, string sortOrder = "desc")
    {
        try
        {
            // Kiểm tra xem StudentId có tồn tại không
            var studentExists = await _unitOfWork.StudentRepository.GetAsync(s => s.StudentId == studentId) != null;
            if (!studentExists)
            {
                return new ResponseDTO
                {
                    Message = "Student not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            // Lấy danh sách CourseBookmark của Student
            var courseBookmarksQuery =
                _unitOfWork.CourseBookmarkRepository.GetAllAsync(cb => cb.StudentId == studentId);

            var courseBookmarks = (await courseBookmarksQuery).ToList();

            // Sắp xếp danh sách CourseBookmark
            switch (sortOrder.Trim().ToLower())
            {
                case "asc":
                    courseBookmarks = courseBookmarks.OrderBy(cb => cb.CreatedTime).ToList();
                    break;
                case "desc":
                    courseBookmarks = courseBookmarks.OrderByDescending(cb => cb.CreatedTime).ToList();
                    break;
                default:
                    // Default sorting by CreatedTime descending
                    courseBookmarks = courseBookmarks.OrderByDescending(cb => cb.CreatedTime).ToList();
                    break;
            }

            return new ResponseDTO
            {
                Message = "Get all bookmarked courses by student ID successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = courseBookmarks
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> CreateBookMarkedCourse(ClaimsPrincipal User,
        CreateCourseBookmarkDTO createCourseBookmarkDTO)
    {
        try
        {
            //Check if studentId is valid
            var id = await _unitOfWork.StudentRepository.GetAsync(i =>
                i.StudentId == createCourseBookmarkDTO.StudentId);
            if (id == null)
            {
                return new ResponseDTO()
                {
                    Message = "StudentID Invalid",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            //Check CourseId is already bookmarked
            var course = await _unitOfWork.CourseBookmarkRepository.GetAsync(c =>
                c.CourseId == createCourseBookmarkDTO.CourseId && c.StudentId == createCourseBookmarkDTO.StudentId);
            if (course != null)
            {
                return new ResponseDTO()
                {
                    Message = "Course is already bookmarked",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            //Create new bookmarked course
            var courseBookmark = new CourseBookmark()
            {
                StudentId = createCourseBookmarkDTO.StudentId,
                CourseId = createCourseBookmarkDTO.CourseId,
                CreatedTime = DateTime.UtcNow,
                CreatedBy = User.Identity.Name,
            };
            //Add new bookmarked course to database
            await _unitOfWork.CourseBookmarkRepository.AddAsync(courseBookmark);
            await _unitOfWork.SaveAsync();
            //Return response
            return new ResponseDTO()
            {
                Message = "Course bookmarked successfully.",
                Result = null,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> DeleteBookMarkedCourse(Guid Id)
    {
        try
        {
            var courseBookmark = await _unitOfWork.CourseBookmarkRepository.GetAsync(
                x => x.Id == Id);

            if (courseBookmark is null)
            {
                return new ResponseDTO
                {
                    Message = "Course bookmark not found.",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            _unitOfWork.CourseBookmarkRepository.Remove(courseBookmark);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Course bookmark removed successfully.",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }


    public async Task<ResponseDTO> GetBestCoursesSuggestion()
    {
        try
        {
            // Get all courses and sort by TotalStudent in descending order
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();

            var bestCourses = courses
                .OrderByDescending(c => c.TotalStudent)
                .Take(10)
                .ToList();

            return new ResponseDTO
            {
                Result = bestCourses,
                Message = "Get best courses suggestion successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    public async Task<List<Category>> GetTopTrendingCategories()
    {
        try
        {
            // Get all courses
            var courses = await _unitOfWork.CourseRepository.GetAllAsync(
                filter: x => x.TotalStudent.HasValue
            );

            if (courses == null || !courses.Any()) 
            { 
                return new List<Category>();
            }

                // Get all course versions including their categories
                var courseVersionIds = courses.Select(c => c.CourseVersionId).Distinct();
            var courseVersions = await _unitOfWork.CourseVersionRepository.GetAllAsync(
                filter: cv => courseVersionIds.Contains(cv.Id)
            );

            // Aggregate total students per category
            var categoryStudentCounts = courseVersions
                .GroupBy(cv => cv.CategoryId)
                .Select(g => new
                {
                    CategoryId = g.Key,
                    TotalStudents = courses
                        .Where(c => c.CourseVersionId.HasValue &&
                                    g.Select(cv => cv.Id).Contains(c.CourseVersionId.Value))
                        .Sum(c => c.TotalStudent.GetValueOrDefault())
                })
                .OrderByDescending(x => x.TotalStudents)
                .Take(3)
                .ToList();

            if (!categoryStudentCounts.Any())
            {
                // No category student counts found, return an empty list
                return new List<Category>();
            }

            // Get the categories
            var categoryIds = categoryStudentCounts.Select(x => x.CategoryId).ToList();
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync(
                filter: c => categoryIds.Contains(c.Id)
            );

            return categories.ToList();
        }
        catch (Exception ex)
        {
            // Handle exception (logging, rethrowing, etc.)
            throw new Exception("An error occurred while getting trending categories.", ex);
        }
    }

    public async Task<ResponseDTO> GetTopCoursesByTrendingCategories()
    {
        try
        {
            // Get the top trending categories
            var trendingCategories = await GetTopTrendingCategories();

            var coursesByCategory = new Dictionary<string, List<Course>>();

            foreach (var category in trendingCategories)
            {
                // Get course versions for the current trending category
                var courseVersionsInCategory = await _unitOfWork.CourseVersionRepository.GetAllAsync(
                    filter: cv => cv.CategoryId == category.Id
                );

                var courseVersionIds = courseVersionsInCategory
                    .Select(cv => cv.Id)
                    .Distinct()
                    .ToList();

                // Get courses for these course versions
                // Get all courses
                var allCourses = await _unitOfWork.CourseRepository.GetAllAsync(
                    filter: c => c.TotalStudent.HasValue
                );

                // Filter courses by total students and take the top 10
                var topCoursesInCategory = allCourses
                    .OrderByDescending(c => c.TotalStudent.GetValueOrDefault())
                    .Take(10)
                    .ToList();

                coursesByCategory[category.Name] = topCoursesInCategory;
            }

            return new ResponseDTO
            {
                Result = coursesByCategory,
                Message = "Get top courses by trending categories successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> GetTopRatedCourses()
    {
        try
        {
            // Fetch all courses
            var courses = await _unitOfWork.CourseRepository.GetAllAsync(
                filter: c => c.TotalRate.HasValue
            );

            // Sort courses by TotalRate in descending order and take the top 10
            var topRatedCourses = courses
                .OrderByDescending(c => c.TotalRate.GetValueOrDefault())
                .Take(10)
                .ToList();

            return new ResponseDTO
            {
                Result = topRatedCourses,
                Message = "Get top rated courses successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> GetCourseRateTotal(Guid courseId)
    {
        try
        {
            // Fetch all courses
            var course = await _unitOfWork.CourseRepository.GetAsync(
                filter: c => c.Id == courseId
            );

            if (course is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            return new ResponseDTO
            {
                Result = new
                {
                    Rate = course.TotalRate
                },
                Message = "Get course total rate successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> GetCourseSlotTotal(Guid courseId)
    {
        try
        {
            // Fetch all courses
            var course = await _unitOfWork.CourseRepository.GetAsync(
                filter: c => c.Id == courseId
            );

            if (course is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            return new ResponseDTO
            {
                Result = new
                {
                    Slot = course.TotalStudent
                },
                Message = "Get course total slot successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Message = ex.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }
}