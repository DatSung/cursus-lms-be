using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service
{
    public class CourseReviewService : ICourseReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseReviewService(IUnitOfWork unitOfWork, IMapper mapper, ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _courseService = courseService;
        }

        public async Task<ResponseDTO> GetCourseReviews
        (
            ClaimsPrincipal User,
            Guid? courseId,
            string? filterOn,
            string? filterQuery,
            string? sortBy,
            bool? isAscending,
            int pageNumber,
            int pageSize
        )
        {
            try
            {
                if (courseId == null)
                {
                    return new ResponseDTO()
                    {
                        Message = "Course ID is required",
                        IsSuccess = false,
                        StatusCode = 400,
                        Result = null
                    };
                }

                var courseReviews = await _unitOfWork.CourseReviewRepository.GetAllAsync(
                    filter: x => x.CourseId == courseId
                );

                if (!courseReviews.Any())
                {
                    return new ResponseDTO()
                    {
                        Message = "There are no course reviews",
                        Result = courseReviews,
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                // Filter Query
                if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
                {
                    switch (filterOn.Trim().ToLower())
                    {
                        case "message":
                            courseReviews = courseReviews.Where(x =>
                                x.Message.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                            break;
                        case "rate":
                            courseReviews = courseReviews.Where(x =>
                                x.Rate.ToString() == filterQuery).ToList();
                            break;
                    }
                }

                // Sort Query
                if (!string.IsNullOrEmpty(sortBy))
                {
                    switch (sortBy.Trim().ToLower())
                    {
                        case "message":
                            courseReviews = isAscending == true
                                ? courseReviews.OrderBy(x => x.Message).ToList()
                                : courseReviews.OrderByDescending(x => x.Message).ToList();
                            break;
                        case "rate":
                            courseReviews = isAscending == true
                                ? courseReviews.OrderBy(x => x.Rate).ToList()
                                : courseReviews.OrderByDescending(x => x.Rate).ToList();
                            break;
                        default:
                            break;
                    }
                }

                // Pagination
                if (pageNumber > 0 && pageSize > 0)
                {
                    var skipResult = (pageNumber - 1) * pageSize;
                    courseReviews = courseReviews.Skip(skipResult).Take(pageSize).ToList();
                }

                if (!courseReviews.Any())
                {
                    return new ResponseDTO()
                    {
                        Message = "There are no course reviews",
                        Result = courseReviews,
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                var courseReviewDto = _mapper.Map<List<GetCourseReviewDTO>>(courseReviews);

                return new ResponseDTO()
                {
                    Result = courseReviewDto,
                    Message = "Get course reviews successfully",
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    Result = null,
                    Message = ex.Message,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseDTO> GetCourseReviewById(Guid id)
        {
            try
            {
                var courseReview = await _unitOfWork.CourseReviewRepository.GetById(id);
                if (courseReview == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course review not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                return new ResponseDTO
                {
                    Message = "Course review retrieved successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = courseReview
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

        public async Task<ResponseDTO> CreateCourseReview
        (
            ClaimsPrincipal User,
            CreateCourseReviewDTO createCourseReviewDTO
        )
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
                var studentId = _unitOfWork.StudentRepository
                    .GetByUserId(userId)
                    .GetAwaiter()
                    .GetResult()!
                    .StudentId;

                createCourseReviewDTO.StudentId = studentId;

                // Validate if the course exists
                var course = await _unitOfWork.CourseRepository.GetById(createCourseReviewDTO.CourseId);
                if (course == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                // Validate if the student exists
                var student = await _unitOfWork.StudentRepository.GetById(createCourseReviewDTO.StudentId);
                if (student == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Student not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                var studentCourse = await _unitOfWork.StudentCourseRepository
                    .GetAsync(
                        x => x.CourseId == createCourseReviewDTO.CourseId
                             && x.StudentId == createCourseReviewDTO.StudentId
                    );

                if (studentCourse is null)
                {
                    return new ResponseDTO()
                    {
                        Message = "Student did not own this course",
                        IsSuccess = false,
                        StatusCode = 400,
                        Result = null
                    };
                }

                // Create new CourseReview
                var courseReview = new CourseReview
                {
                    Id = Guid.NewGuid(),
                    CourseId = createCourseReviewDTO.CourseId,
                    StudentId = createCourseReviewDTO.StudentId,
                    Rate = createCourseReviewDTO.Rate,
                    Message = createCourseReviewDTO.Message,
                    CreatedBy = createCourseReviewDTO.StudentId.ToString(), // Or fetch the actual student info
                    CreatedTime = DateTime.Now,
                    Status = StaticStatus.CourseReview.Activated // Active status
                };

                await _unitOfWork.CourseReviewRepository.AddAsync(courseReview);
                await _unitOfWork.SaveAsync();

                await _courseService.UpsertCourseTotal
                (
                    new UpsertCourseTotalDTO()
                    {
                        CourseId = course.Id,
                        UpdateTotalRate = true
                    }
                );

                return new ResponseDTO
                {
                    Message = "Course review created successfully",
                    IsSuccess = true,
                    StatusCode = 201,
                    Result = courseReview.Id
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

        public async Task<ResponseDTO> UpdateCourseReview(ClaimsPrincipal User,
            UpdateCourseReviewDTO updateCourseReviewDTO)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (userId is null)
                {
                    return new ResponseDTO
                    {
                        Message = "User not found",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                var courseReview = await _unitOfWork.CourseReviewRepository.GetById(updateCourseReviewDTO.Id);
                if (courseReview == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course review not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                courseReview.Rate = updateCourseReviewDTO.Rate;
                courseReview.Message = updateCourseReviewDTO.Message;
                courseReview.UpdatedBy = userId;
                courseReview.UpdatedTime = DateTime.UtcNow;

                _unitOfWork.CourseReviewRepository.Update(courseReview);
                await _unitOfWork.SaveAsync();

                await _courseService.UpsertCourseTotal
                (
                    new UpsertCourseTotalDTO()
                    {
                        CourseId = courseReview.CourseId,
                        UpdateTotalRate = true
                    }
                );

                return new ResponseDTO
                {
                    Message = "Course review updated successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = courseReview.Id
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

        public async Task<ResponseDTO> DeleteCourseReview(Guid id)
        {
            try
            {
                var courseReview = await _unitOfWork.CourseReviewRepository.GetById(id);
                if (courseReview == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course review not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                _unitOfWork.CourseReviewRepository.Remove(courseReview);
                await _unitOfWork.SaveAsync();

                await _courseService.UpsertCourseTotal
                (
                    new UpsertCourseTotalDTO()
                    {
                        CourseId = courseReview.CourseId,
                        UpdateTotalRate = true
                    }
                );

                return new ResponseDTO
                {
                    Message = "Course review deleted successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = null
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

        public async Task<ResponseDTO> MarkCourseReview(Guid id)
        {
            try
            {
                var courseReview = await _unitOfWork.CourseReviewRepository.GetById(id);
                if (courseReview == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course review not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                courseReview.IsMarked = !courseReview.IsMarked;

                _unitOfWork.CourseReviewRepository.Update(courseReview);
                await _unitOfWork.SaveAsync();

                string message = courseReview.IsMarked
                    ? "Marked the review successfully"
                    : "Unmarked the review successfully";

                return new ResponseDTO
                {
                    Message = message,
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = courseReview.Id
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
}