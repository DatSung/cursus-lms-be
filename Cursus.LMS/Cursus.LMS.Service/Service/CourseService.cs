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

    public CourseService
    (
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IStudentCourseService studentCourseService
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _studentCourseService = studentCourseService;
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
                    IsSuccess = true,
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
            if (string.IsNullOrEmpty(instructorId.ToString()))
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var instructor = await _unitOfWork.InstructorRepository.GetAsync
                (
                    filter: x => x.UserId == userId
                );

                if (instructor is null)
                {
                    return new ResponseDTO()
                    {
                        Message = "Courses was not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                instructorId = instructor.InstructorId;
            }

            var courses = new List<Course>();
            if (string.IsNullOrEmpty(instructorId.ToString()))
            {
                courses = _unitOfWork.CourseRepository
                    .GetAllAsync
                    (
                        includeProperties: "Course,Category,Level"
                    )
                    .GetAwaiter()
                    .GetResult()
                    .ToList();
            }
            else
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

            // Pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                courseVersions = courseVersions.Skip(skipResult).Take(pageSize).ToList();
            }

            var courseVersionDto = _mapper.Map<List<GetCourseVersionDTO>>(courseVersions);

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
            // Lấy danh sách StudentCourse ban đầu
            var studentCoursesQuery = _unitOfWork.StudentCourseRepository.GetAllAsync(
                sc => sc.CreatedTime.HasValue,
                includeProperties: "Course"
            );

            var studentCourses = (await studentCoursesQuery).ToList();

            // Áp dụng bộ lọc theo thời gian
            if (year.HasValue)
            {
                studentCourses = studentCourses
                    .Where(sc => sc.CreatedTime.Value.Year == year.Value)
                    .ToList();
            }

            if (month.HasValue)
            {
                studentCourses = studentCourses
                    .Where(sc => sc.CreatedTime.Value.Month == month.Value)
                    .ToList();
            }

            if (quarter.HasValue)
            {
                int startMonth = (quarter.Value - 1) * 3 + 1;
                int endMonth = startMonth + 2;
                studentCourses = studentCourses
                    .Where(sc => sc.CreatedTime.Value.Month >= startMonth && sc.CreatedTime.Value.Month <= endMonth)
                    .ToList();
            }

            // Lấy danh sách CourseVersionId từ studentCourses
            var courseVersionIds = studentCourses
                .Select(sc => sc.Course.CourseVersionId)
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

            // Lọc lại danh sách studentCourses dựa trên CourseVersion
            studentCourses = studentCourses
                .Where(sc => courseVersions.Any(cv => cv.Id == sc.Course.CourseVersionId))
                .ToList();

            // Sắp xếp danh sách theo thứ tự giảm dần
            studentCourses = studentCourses.OrderByDescending(sc => sc.CreatedTime).ToList();

            // Áp dụng phân trang và giới hạn top
            int skip = (pageNumber - 1) * pageSize;
            studentCourses = studentCourses
                .Skip(skip)
                .Take(pageSize > top ? top : pageSize)
                .ToList();

            return new ResponseDTO
            {
                Result = studentCourses,
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
            // Lấy danh sách StudentCourse ban đầu
            var studentCoursesQuery = _unitOfWork.StudentCourseRepository.GetAllAsync(
                sc => sc.CreatedTime.HasValue,
                includeProperties: "Course"
            );

            var studentCourses = (await studentCoursesQuery).ToList();

            // Áp dụng bộ lọc theo thời gian
            if (year.HasValue)
            {
                studentCourses = studentCourses
                    .Where(sc => sc.CreatedTime.Value.Year == year.Value)
                    .ToList();
            }

            if (month.HasValue)
            {
                studentCourses = studentCourses
                    .Where(sc => sc.CreatedTime.Value.Month == month.Value)
                    .ToList();
            }

            if (quarter.HasValue)
            {
                int startMonth = (quarter.Value - 1) * 3 + 1;
                int endMonth = startMonth + 2;
                studentCourses = studentCourses
                    .Where(sc => sc.CreatedTime.Value.Month >= startMonth && sc.CreatedTime.Value.Month <= endMonth)
                    .ToList();
            }

            // Lấy danh sách CourseVersionId từ studentCourses
            var courseVersionIds = studentCourses
                .Select(sc => sc.Course.CourseVersionId)
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

            // Lọc lại danh sách studentCourses dựa trên CourseVersion
            studentCourses = studentCourses
                .Where(sc => courseVersions.Any(cv => cv.Id == sc.Course.CourseVersionId))
                .ToList();

            // Đếm số lần mua của mỗi khóa học
            var coursePurchaseCounts = studentCourses
                .GroupBy(sc => sc.Course.CourseVersionId)
                .Select(g => new
                {
                    CourseVersionId = g.Key,
                    PurchaseCount = g.Count()
                })
                .OrderBy(g => g.PurchaseCount) // Sắp xếp theo số lượng mua ít nhất
                .Take(top)
                .ToList();

            // Lấy lại danh sách studentCourses dựa trên khóa học ít được mua nhất
            var leastPurchasedCourses = studentCourses
                .Where(sc => coursePurchaseCounts.Any(cpc => cpc.CourseVersionId == sc.Course.CourseVersionId))
                .ToList();

            // Áp dụng phân trang
            int skip = (pageNumber - 1) * pageSize;
            leastPurchasedCourses = leastPurchasedCourses
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return new ResponseDTO
            {
                Result = leastPurchasedCourses,
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

            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == course.CourseVersionId);

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

            var courseVersionDto = _mapper.Map<GetCourseVersionDTO>(courseVersion);

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
            var studentCourse = await _unitOfWork.StudentCourseRepository.GetAsync
            (
                x => x.StudentId == enrollCourseDto.studentId && x.CourseId == enrollCourseDto.courseId
            );

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

            if (studentCourse.Status != StaticStatus.StudentCourse.Pending)
            {
                return new ResponseDTO()
                {
                    Message = "Student was not own this course",
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
            var coursesEnroll = courses.Select(c => c.CourseId).Distinct().ToList();

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
                IsSuccess = true
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
}