using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service
{
    public class CourseReviewService : ICourseReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task<ResponseDTO> CreateCourseReview(CreateCourseReviewDTO createCourseReviewDTO)
        {
            try
            {
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

                // Create new CourseReview
                var courseReview = new CourseReview
                {
                    Id = Guid.NewGuid(),
                    CourseId = createCourseReviewDTO.CourseId,
                    StudentId = createCourseReviewDTO.StudentId,
                    Rate = createCourseReviewDTO.Rate,
                    Message = createCourseReviewDTO.Message,
                    CreatedBy = createCourseReviewDTO.StudentId.ToString(), // Or fetch the actual student info
                    CreatedTime = DateTime.UtcNow,
                    Status = 1 // Active status
                };

                await _unitOfWork.CourseReviewRepository.AddAsync(courseReview);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO
                {
                    Message = "Course review created successfully",
                    IsSuccess = true,
                    StatusCode = 201,
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
        public async Task<ResponseDTO> UpdateCourseReview(UpdateCourseReviewDTO updateCourseReviewDTO)
        {
            try
            {
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
                courseReview.UpdatedTime = DateTime.UtcNow;

                _unitOfWork.CourseReviewRepository.Update(courseReview);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO
                {
                    Message = "Course review updated successfully",
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


    }
}
