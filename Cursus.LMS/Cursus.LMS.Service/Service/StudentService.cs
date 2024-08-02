using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Hubs;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service
{
    public class StudentService : IStudentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClosedXMLService _closedXmlService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper,
            IClosedXMLService closedXmlService, IHubContext<NotificationHub> notificationHub,
            IWebHostEnvironment env, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _closedXmlService = closedXmlService;
            _notificationHub = notificationHub;
            _env = env;
            _config = config;
        }

        //Get all students đã xong
        public async Task<ResponseDTO> GetAllStudent
        (
            ClaimsPrincipal User,
            string? filterOn,
            string? filterQuery,
            string? sortBy,
            bool? isAscending,
            int pageNumber,
            int pageSize
        )
        {
            #region MyRegion

            try
            {
                List<Student> students = new List<Student>();

                // Filter Query
                if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
                {
                    switch (filterOn.Trim().ToLower())
                    {
                        case "name":
                        {
                            students = _unitOfWork.StudentRepository.GetAllAsync(includeProperties: "ApplicationUser")
                                .GetAwaiter().GetResult().Where(x =>
                                    x.ApplicationUser.FullName.Contains(filterQuery,
                                        StringComparison.CurrentCultureIgnoreCase)).ToList();
                            break;
                        }
                        case "email":
                        {
                            students = _unitOfWork.StudentRepository.GetAllAsync(includeProperties: "ApplicationUser")
                                .GetAwaiter().GetResult().Where(x =>
                                    x.ApplicationUser.Email.Contains(filterQuery,
                                        StringComparison.CurrentCultureIgnoreCase)).ToList();
                            break;
                        }
                        default:
                        {
                            students = _unitOfWork.StudentRepository.GetAllAsync(includeProperties: "ApplicationUser")
                                .GetAwaiter().GetResult().ToList();
                            break;
                        }
                    }
                }
                else
                {
                    students = _unitOfWork.StudentRepository.GetAllAsync(includeProperties: "ApplicationUser")
                        .GetAwaiter().GetResult().ToList();
                }

                // Sort Query
                if (!string.IsNullOrEmpty(sortBy))
                {
                    switch (sortBy.Trim().ToLower())
                    {
                        case "name":
                        {
                            students = isAscending == true
                                ? [.. students.OrderBy(x => x.ApplicationUser.FullName)]
                                : [.. students.OrderByDescending(x => x.ApplicationUser.FullName)];
                            break;
                        }
                        case "email":
                        {
                            students = isAscending == true
                                ? [.. students.OrderBy(x => x.ApplicationUser.Email)]
                                : [.. students.OrderByDescending(x => x.ApplicationUser.Email)];
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
                    students = students.Skip(skipResult).Take(pageSize).ToList();
                }

                #endregion Query Parameters

                if (students == null || !students.Any())
                {
                    return new ResponseDTO()
                    {
                        Message = "There are no Students",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                var studentInfoDtoList = new List<StudentInfoDTO>();

                foreach (var student in students)
                {
                    var studentInfoDto = new StudentInfoDTO
                    {
                        StudentId = student.StudentId,
                        FullName = student.ApplicationUser?.FullName,
                        Email = student.ApplicationUser?.Email,
                        PhoneNumber = student.ApplicationUser?.PhoneNumber,
                    };

                    studentInfoDtoList.Add(studentInfoDto);
                }

                return new ResponseDTO()
                {
                    Message = "Get all students successfully",
                    Result = studentInfoDtoList,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        //GetById đã xong
        public async Task<ResponseDTO> GetById(Guid id)
        {
            {
                try
                {
                    var student = await _unitOfWork.StudentRepository.GetById(id);
                    if (student is null)
                    {
                        return new ResponseDTO()
                        {
                            Message = "Instructor was not found",
                            IsSuccess = false,
                            StatusCode = 404,
                            Result = null
                        };
                    }

                    StudentFullInfoDTO studentFullInfoDto = new StudentFullInfoDTO()
                    {
                        StudentId = student.StudentId,
                        UserId = student.UserId,
                        AvatarUrl = student.ApplicationUser.AvatarUrl,
                        FullName = student.ApplicationUser.FullName,
                        University = student.University,
                        Email = student.ApplicationUser.Email,
                        Address = student.ApplicationUser.Address,
                        BirthDate = student.ApplicationUser.BirthDate,
                        Country = student.ApplicationUser.Country,
                        Gender = student.ApplicationUser.Gender,
                        PhoneNumber = student.ApplicationUser.PhoneNumber,
                    };

                    return new ResponseDTO()
                    {
                        Message = "Get instructor successfully ",
                        IsSuccess = false,
                        StatusCode = 200,
                        Result = studentFullInfoDto
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

        //UpdateById đã xong
        public async Task<ResponseDTO> UpdateById(UpdateStudentDTO updateStudentDTO)
        {
            try
            {
                var studentToUpdate =
                    await _unitOfWork.StudentRepository.GetById(updateStudentDTO.StudentId);

                if (studentToUpdate == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Student not found",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                studentToUpdate.ApplicationUser.FullName = updateStudentDTO?.FullName;
                studentToUpdate.University = updateStudentDTO.University;
                studentToUpdate.ApplicationUser.Address = updateStudentDTO?.Address;
                studentToUpdate.ApplicationUser.BirthDate = updateStudentDTO?.BirthDate;
                studentToUpdate.ApplicationUser.Gender = updateStudentDTO?.Gender;
                studentToUpdate.ApplicationUser.Country = updateStudentDTO?.Country;
                studentToUpdate.ApplicationUser.UpdateTime = DateTime.Now;


                _unitOfWork.StudentRepository.Update(studentToUpdate);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO
                {
                    Message = "Student updated successfully",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        //activate Student đã xong
        public async Task<ResponseDTO> ActivateStudent(ClaimsPrincipal User, Guid studentId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var student = await _unitOfWork.StudentRepository.GetById(studentId);
                if (student is null)
                {
                    return new ResponseDTO()
                    {
                        Message = "Student was not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                student.ApplicationUser.LockoutEnabled = true;
                student.ApplicationUser.LockoutEnd = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    Message = "Active student successfully",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                    Message = e.Message,
                    IsSuccess = true,
                    StatusCode = 500,
                    Result = null
                };
            }
        }

        //Deactivate Student đã xong
        public async Task<ResponseDTO> DeactivateStudent(ClaimsPrincipal User, Guid studentId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                var student = await _unitOfWork.StudentRepository.GetById(studentId);
                if (student is null)
                {
                    return new ResponseDTO()
                    {
                        Message = "Student was not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                student.ApplicationUser.LockoutEnabled = false;
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    Message = "Reject instructor successfully",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                    Message = e.Message,
                    IsSuccess = true,
                    StatusCode = 500,
                    Result = null
                };
            }
        }

        //GetStudentTotalCourses đã xong
        public async Task<ResponseDTO> GetStudentTotalCourses(Guid studentId)
        {
            try
            {
                var id = await _unitOfWork.StudentRepository.GetAsync(i => i.StudentId == studentId);

                if (id == null)
                {
                    return new ResponseDTO()
                    {
                        Message = "StudentId Invalid",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 400
                    };
                }

                var courses = await _unitOfWork.StudentCourseStatusRepository.GetAllAsync(c => c.Id == id.StudentId);

                var totalCourses = courses.Count();
                var pending = courses.Count(x => x.Status == 0);
                var enrolled = courses.Count(x => x.Status == 1);
                var completed = courses.Count(x => x.Status == 3);
                var canceled = courses.Count(x => x.Status == 4);

                return new ResponseDTO()
                {
                    Message = "Get Course Successfull",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = new StudentTotalCountDTO()
                    {
                        Total = totalCourses,
                        Pending = pending,
                        Enrolled = enrolled,
                        Completed = completed,
                        Canceled = canceled
                    }
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseDTO> GetAllCourseStudentEnrolled(Guid studentId)
        {
            try
            {
                // Kiểm tra studentId có tồn tại không
                var student = await _unitOfWork.StudentRepository.GetAsync(i => i.StudentId == studentId);
                if (student == null)
                {
                    return new ResponseDTO()
                    {
                        Message = "StudentID Invalid",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 400
                    };
                }

                // Lấy danh sách CourseId mà học viên đã đăng ký và đang học
                var enrolledCourseIds = (await _unitOfWork.StudentCourseRepository
                        .GetAllAsync(
                            sc => sc.StudentId == studentId && sc.Status == StaticStatus.StudentCourse.Enrolled))
                    .Select(sc => sc.CourseId)
                    .Distinct()
                    .ToList();

                if (!enrolledCourseIds.Any())
                {
                    return new ResponseDTO()
                    {
                        Message = "Student has not enrolled in any courses",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                // Lấy danh sách các CourseVersion dựa trên CourseId
                var courseVersions = await _unitOfWork.CourseVersionRepository
                    .GetAllAsync(cv => enrolledCourseIds.Contains(cv.CourseId), includeProperties: "Course,Category");

                // Chuyển đổi danh sách khóa học thành DTO
                var courseEnrolledDtos = new List<CourseEnrolledDTO>();

                foreach (var cv in courseVersions)
                {
                    var instructor = await _unitOfWork.InstructorRepository.GetAsync(
                        x => x.InstructorId == cv.InstructorId, includeProperties: "ApplicationUser");
                    var instructorName = instructor.ApplicationUser.FullName;

                    courseEnrolledDtos.Add(new CourseEnrolledDTO()
                    {
                        CourseName = cv.Title,
                        CourseImage = cv.CourseImgUrl,
                        CourseRate = (float)cv.Course.TotalRate,
                        CourseSummary = cv.Description.Length > 200
                            ? cv.Description.Substring(0, 200) + "..."
                            : cv.Description,
                        Category = cv.Category.Name,
                        InstructorName = instructorName
                    });
                }

                return new ResponseDTO()
                {
                    Message = "Get Student Course Enrolled Successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = courseEnrolledDtos
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseDTO> GetAllStudentComment
        (
            Guid studentId, int pageNumber, int pageSize
        )
        {
            try
            {
                var comments = _unitOfWork.StudentCommentRepository.GetAllAsync(
                    x => x.StudentId == studentId &&
                         x.Status != 2
                ).GetAwaiter().GetResult().ToList();
                if (comments is null)
                {
                    return new ResponseDTO()
                    {
                        Message = "There are no comment",
                        IsSuccess = true,
                        StatusCode = 204,
                        Result = null
                    };
                }

                comments = comments.OrderByDescending(x => x.CreatedTime).ToList();

                // Pagination
                if (pageNumber > 0 && pageSize > 0)
                {
                    var skipResult = (pageNumber - 1) * pageSize;
                    comments = comments.Skip(skipResult).Take(pageSize).ToList();
                }

                var commentsDto = _mapper.Map<List<GetAllCommentsDTO>>(comments);

                return new ResponseDTO()
                {
                    Message = "Get student comment successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = commentsDto
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        //CreateStudentComment đã xong
        public async Task<ResponseDTO> CreateStudentComment(ClaimsPrincipal User,
            CreateStudentCommentDTO createStudentCommentDTO)
        {
            try
            {
                var studentId =
                    await _unitOfWork.StudentRepository.GetAsync(i =>
                        i.StudentId == createStudentCommentDTO.StudentId);
                if (studentId is null)
                {
                    return new ResponseDTO()
                    {
                        Message = "StudentId Invalid",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

                StudentComment studentComment = new StudentComment()
                {
                    Comment = createStudentCommentDTO.Comment,
                    StudentId = createStudentCommentDTO.StudentId,
                    UpdatedTime = null,
                    CreatedTime = DateTime.Now,
                    CreatedBy = admin.Email,
                    UpdatedBy = "",
                    Status = 0
                };

                await _unitOfWork.StudentCommentRepository.AddAsync(studentComment);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    Message = "Create student comment successfully",
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
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = null
                };
            }
        }

        //UpdateStudentComment đã xong
        public async Task<ResponseDTO> UpdateStudentComment(ClaimsPrincipal User,
            UpdateStudentCommentDTO updateStudentCommentDTO)
        {
            try
            {
                var studentId =
                    await _unitOfWork.StudentCommentRepository.GetAsync(i => i.Id == updateStudentCommentDTO.Id);
                if (studentId == null)
                {
                    return new ResponseDTO()
                    {
                        Message = "StudentId Invalid",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 400
                    };
                }

                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

                //update comment
                studentId.UpdatedTime = DateTime.Now;
                studentId.UpdatedBy = admin.Email;
                studentId.Comment = updateStudentCommentDTO.Comment;
                studentId.Status = 1;

                _unitOfWork.StudentCommentRepository.Update(studentId);

                //Lưu comment
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    Message = "Comment updated successfully",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200,
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        //DeleteStudentComment đã xong
        public async Task<ResponseDTO> DeleteStudentComment(Guid commentId)
        {
            try
            {
                var comment =
                    await _unitOfWork.StudentCommentRepository.GetAsync(x => x.Id == commentId);
                if (comment == null)
                {
                    return new ResponseDTO()
                    {
                        Message = "Comment was not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null,
                    };
                }

                //chuyển status về 0 chứ không xóa dữ liệu
                comment.Status = 2;
                //Lưu thay đổi
                _unitOfWork.StudentCommentRepository.Update(comment);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    Message = "Comment deleted successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = comment.Id,
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        //ExportStudents đã xong
        public async Task<ResponseDTO> ExportStudents(string userId, int month, int year)
        {
            // Lấy dữ liệu từ repository
            var students = _unitOfWork.StudentRepository.GetAllAsync(includeProperties: "ApplicationUser")
                .GetAwaiter().GetResult().ToList();

            // Lọc dữ liệu theo tháng và năm
            students = students.Where(x =>
                    x.ApplicationUser.CreateTime.HasValue && x.ApplicationUser.CreateTime.Value.Month == month &&
                    x.ApplicationUser.CreateTime.Value.Year == year)
                .ToList();

            // Map dữ liệu sang DTO
            var studentInfoDtos = _mapper.Map<List<StudentFullInfoDTO>>(students);

            // Xuất file Excel
            var fileStudent = await _closedXmlService.ExportStudentExcel(studentInfoDtos);

            // Gửi tín hiệu cho người dùng sau khi xuất file
            await _notificationHub.Clients.User(userId).SendAsync("DownloadExcelNow", fileStudent);

            return new ResponseDTO()
            {
                Message = "Waiting...",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
            };
        }

        //DownloadStudents đã xong
        public async Task<ClosedXMLResponseDTO> DownloadStudents(string fileName)
        {
            try
            {
                string filePath = Path.Combine(_env.ContentRootPath, _config["FolderPath:StudentExportFolderPath"],
                    fileName);

                if (!File.Exists(filePath))
                {
                    return new ClosedXMLResponseDTO()
                    {
                        Message = "File not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Stream = null,
                        ContentType = null,
                        FileName = null
                    };
                }

                // Read the file
                var memoryStream = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memoryStream);
                }

                memoryStream.Position = 0;
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                //Delete file after download
                File.Delete(filePath);

                return new ClosedXMLResponseDTO()
                {
                    Message = "Download file successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Stream = memoryStream,
                    ContentType = contentType,
                    FileName = fileName
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<ResponseDTO> TotalPricesCoursesByStudentId(Guid studentId)
        {
            try
            {
                // kiểm tra studentId có tồn tại không
                var student = await _unitOfWork.StudentRepository.GetAsync(s => s.StudentId == studentId);

                if (student == null)
                {
                    return new ResponseDTO()
                    {
                        Message = "StudentId Invalid",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 400
                    };
                }

                // Lấy danh sách các OrderHeader của student đó
                var orderHeaders = await _unitOfWork.OrderHeaderRepository.GetAllAsync(o => o.StudentId == studentId);
                //kiểm tra xem student đã mua khóa học nào chưa
                if (orderHeaders == null || !orderHeaders.Any())
                {
                    return new ResponseDTO()
                    {
                        Message = "Student has not purchased any courses",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 400
                    };
                }

                // Lấy danh sách các OrderHeader
                var orderHeaderId = orderHeaders.Select(x => x.Id).ToList();

                // Lấy danh sách các OrderDetails của orderHeader
                var orderDetails = await _unitOfWork.OrderDetailsRepository.GetAllAsync(
                    od => orderHeaderId.Contains(od.OrderHeaderId) && od.CourseId != Guid.Empty);

                // Đếm số lượng khóa học
                var courses = orderDetails.Count();

                // Tính tổng giá của các khóa học
                var totalPrice = orderDetails.Sum(od => od.CoursePrice);

                return new ResponseDTO()
                {
                    Message = "Get total money successfully",
                    Result = new { Courses = courses, TotalPrice = totalPrice },
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseDTO> GetAllCourseByStudentId(ClaimsPrincipal User,
            CourseByStudentDTO courseByStudentDTO)
        {
            try
            {
                Guid? studentId = null;
                var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

                if (role != null && role.Contains(StaticUserRoles.Student))
                {
                    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    var student = await _unitOfWork.StudentRepository.GetAsync(i => i.UserId == userId);

                    if (student != null)
                    {
                        studentId = student.StudentId;
                    }
                }

                if (role != null && role.Contains(StaticUserRoles.Admin))
                {
                    if (studentId == null)
                    {
                        return new ResponseDTO()
                        {
                            Message = "Student was not found",
                            IsSuccess = false,
                            StatusCode = 404,
                            Result = null
                        };
                    }
                }

                var courses = await _unitOfWork.StudentCourseRepository.GetAllAsync(
                    c => c.StudentId == studentId,
                    includeProperties: "Course.Instructor.ApplicationUser"
                );

                if (courses == null || !courses.Any())
                {
                    return new ResponseDTO()
                    {
                        Message = "Student don't have any courses",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                var listCourses = courses.Select(cs => new CourseByStudentDTO
                {
                    CourseId = cs.Id,
                    StudentId = cs.StudentId,
                    CourseVersionId = cs.CourseId,
                    CertificateImgUrl = cs.CertificateImgUrl,
                    CreatedTime = cs.CreatedTime,
                    UpdatedTime = cs.UpdatedTime,
                    Status = cs.Status,
                    InstructorName = cs.Course.Instructor.ApplicationUser.FullName
                }).ToList();

                return new ResponseDTO()
                {
                    Message = "Get all courses successfully",
                    Result = listCourses,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                    Message = e.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }
        }
    }

}