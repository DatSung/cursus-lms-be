using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Hubs;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using DocumentFormat.OpenXml.Office2019.Word.Cid;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static Cursus.LMS.Utility.Constants.StaticStatus;
using Task = DocumentFormat.OpenXml.Office2021.DocumentTasks.Task;

namespace Cursus.LMS.Service.Service;

public class InstructorService : IInstructorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClosedXMLService _closedXmlService;
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;
    private readonly IHubContext<NotificationHub> _notificationHub;

    public InstructorService(IUnitOfWork unitOfWork, IMapper mapper, IClosedXMLService closedXmlService,
        IWebHostEnvironment env, IConfiguration config, IHubContext<NotificationHub> notificationHub)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _closedXmlService = closedXmlService;
        _env = env;
        _config = config;
        _notificationHub = notificationHub;
    }


    public async Task<ResponseDTO> GetAll
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
            List<Instructor> instructors = new List<Instructor>();

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "name":
                    {
                        instructors = _unitOfWork.InstructorRepository.GetAllAsync(includeProperties: "ApplicationUser")
                            .GetAwaiter().GetResult().Where(x =>
                                x.ApplicationUser.FullName.Contains(filterQuery,
                                    StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "email":
                    {
                        instructors = _unitOfWork.InstructorRepository.GetAllAsync(includeProperties: "ApplicationUser")
                            .GetAwaiter().GetResult().Where(x =>
                                x.ApplicationUser.Email.Contains(filterQuery,
                                    StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    default:
                    {
                        instructors = _unitOfWork.InstructorRepository.GetAllAsync(includeProperties: "ApplicationUser")
                            .GetAwaiter().GetResult().ToList();
                        break;
                    }
                }
            }
            else
            {
                instructors = _unitOfWork.InstructorRepository.GetAllAsync(includeProperties: "ApplicationUser")
                    .GetAwaiter().GetResult().ToList();
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "name":
                    {
                        instructors = isAscending == true
                            ? [.. instructors.OrderBy(x => x.ApplicationUser.FullName)]
                            : [.. instructors.OrderByDescending(x => x.ApplicationUser.FullName)];
                        break;
                    }
                    case "email":
                    {
                        instructors = isAscending == true
                            ? [.. instructors.OrderBy(x => x.ApplicationUser.Email)]
                            : [.. instructors.OrderByDescending(x => x.ApplicationUser.Email)];
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
                instructors = instructors.Skip(skipResult).Take(pageSize).ToList();
            }

            #endregion Query Parameters

            if (instructors.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "There are no instructors",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var instructorInfoLiteDto = _mapper.Map<List<InstructorInfoLiteDTO>>(instructors);

            return new ResponseDTO()
            {
                Message = "Get all category successfully",
                Result = instructorInfoLiteDto,
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

    public async Task<ResponseDTO> GetById(Guid id)
    {
        try
        {
            var instructor = await _unitOfWork.InstructorRepository.GetById(id);
            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var paymentCard = await _unitOfWork.PaymentCardRepository.GetCardByUserId(instructor.UserId);

            InstructorInfoDTO instructorInfoDto = new InstructorInfoDTO()
            {
                InstructorId = instructor.InstructorId,
                UserId = instructor.UserId,
                FullName = instructor.ApplicationUser.FullName,
                Email = instructor.ApplicationUser.Email,
                Address = instructor.ApplicationUser.Address,
                PhoneNumber = instructor.ApplicationUser.PhoneNumber,
                Gender = instructor.ApplicationUser.Gender,
                BirthDate = instructor.ApplicationUser.BirthDate,
                Country = instructor.ApplicationUser.Country,
                Degree = instructor.Degree,
                Industry = instructor.Industry,
                Introduction = instructor.Introduction,
                TaxNumber = instructor.ApplicationUser.TaxNumber,
                CardNumber = paymentCard?.CardNumber,
                CardName = paymentCard?.CardName,
                CardProvider = paymentCard?.CardProvider,
                IsAccepted = instructor.IsAccepted
            };

            return new ResponseDTO()
            {
                Message = "Get instructor successfully ",
                IsSuccess = false,
                StatusCode = 200,
                Result = instructorInfoDto
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


    /// <summary>
    /// 
    /// </summary>
    /// <param name="updateInstructorDto"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> UpdateById(UpdateInstructorDTO updateInstructorDto)
    {
        try
        {
            var instructorToUpdate =
                await _unitOfWork.InstructorRepository.GetById(updateInstructorDto.InstructorId);

            if (instructorToUpdate == null)
            {
                return new ResponseDTO
                {
                    Message = "Instructor not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            instructorToUpdate.Degree = updateInstructorDto.Degree;
            instructorToUpdate.Industry = updateInstructorDto.Industry;
            instructorToUpdate.Introduction = updateInstructorDto.Introduction;

            instructorToUpdate.ApplicationUser.Address = updateInstructorDto?.Address;
            instructorToUpdate.ApplicationUser.BirthDate = updateInstructorDto?.BirthDate;
            instructorToUpdate.ApplicationUser.PhoneNumber = updateInstructorDto?.PhoneNumber;
            instructorToUpdate.ApplicationUser.Gender = updateInstructorDto?.Gender;
            instructorToUpdate.ApplicationUser.FullName = updateInstructorDto?.FullName;
            instructorToUpdate.ApplicationUser.Country = updateInstructorDto?.Country;
            instructorToUpdate.ApplicationUser.Email = updateInstructorDto?.Email;
            instructorToUpdate.ApplicationUser.TaxNumber = updateInstructorDto?.TaxNumber;


            _unitOfWork.InstructorRepository.Update(instructorToUpdate);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Instructor updated successfully",
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

    public async Task<ResponseDTO> AcceptInstructor(ClaimsPrincipal User, Guid instructorId)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var instructor = await _unitOfWork.InstructorRepository.GetById(instructorId);
            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            instructor.IsAccepted = true;
            instructor.AcceptedBy = userId;
            instructor.AcceptedTime = DateTime.UtcNow;
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Accept instructor successfully",
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

    public async Task<ResponseDTO> RejectInstructor(ClaimsPrincipal User, Guid instructorId)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var instructor = await _unitOfWork.InstructorRepository.GetById(instructorId);
            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            instructor.IsAccepted = false;
            instructor.RejectedBy = userId;
            instructor.RejectedTime = DateTime.UtcNow;
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

    public Task<ResponseDTO> GetInstructorTotalCourses(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> GetInstructorTotalRating(Guid instructorId)
    {
        try
        {
            // Lấy tất cả rating của Instructor
            var instructorRatings = await _unitOfWork.InstructorRatingRepository.GetAllAsync(x => x.InstructorId == instructorId);

            if (!instructorRatings.Any())
            {
                return new ResponseDTO
                {
                    Message = "No ratings found for this instructor.",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            // Tính tổng số và trung bình tổng Rating
            var totalRating = instructorRatings.Sum(x => x.Rate);

            // Lưu tổng rating vào database
            var instructorRating = new InstructorRating
            {
                Id = Guid.NewGuid(),
                InstructorId = instructorId,
                Rate = (int)totalRating
            };
            await _unitOfWork.InstructorRatingRepository.AddAsync(instructorRating);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Instructor total rating calculated and saved successfully.",
                IsSuccess = true,
                StatusCode = 200,
                Result = totalRating
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


    public Task<ResponseDTO> GetInstructorEarnedMoney(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetInstructorPayoutMoney(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    // Instructor Comment

    public Task<ResponseDTO> GetAllInstructorComment(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> CreateInstructorComment(CreateInstructorCommentDTO createInstructorComment)
    {
        try
        {
            //Map DTO qua entity InstructorComment
            var comment = _mapper.Map<InstructorComment>(createInstructorComment);
            //Tìm xem có đúng ID instructor hay không
            var instructorId =
                await _unitOfWork.InstructorRepository.GetAsync(i =>
                    i.InstructorId == createInstructorComment.instructorId);
            if (instructorId == null)
            {
                return new ResponseDTO()
                {
                    Message = "InstructorId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            //chuyển status về 1
            comment.Status = 1;

            //thêm comment vào cho instructor
            await _unitOfWork.InstructorCommentRepository.AddAsync(comment);
            await _unitOfWork.SaveAsync();
            return new ResponseDTO()
            {
                Message = "Comment created successfully",
                Result = comment,
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

    public async Task<ResponseDTO> UpdateInstructorComment(UpdateInstructorCommentDTO updateInstructorCommentDTO)
    {
        try
        {
            var instructorId =
                await _unitOfWork.InstructorCommentRepository.GetAsync(i => i.Id == updateInstructorCommentDTO.Id);
            if (instructorId == null)
            {
                return new ResponseDTO()
                {
                    Message = "InstructorId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            //update comment
            _mapper.Map(updateInstructorCommentDTO, instructorId);
            _unitOfWork.InstructorCommentRepository.Update(instructorId);

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

    public async Task<ResponseDTO> DeleteInstructorComment(Guid commentId)
    {
        try
        {
            var comment =
                await _unitOfWork.InstructorCommentRepository.GetAsync(x => x.Id == commentId);
            if (comment == null)
            {
                return new ResponseDTO()
                {
                    Message = "Category was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                };
            }

            //chuyển status về 0 chứ không xóa dữ liệu
            comment.Status = 2;
            //Lưu thay đổi
            _unitOfWork.InstructorCommentRepository.Update(comment);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Category deleted successfully",
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

    public async Task<ResponseDTO> ExportInstructors(ClaimsPrincipal User)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var instructors = _unitOfWork.InstructorRepository.GetAllAsync(includeProperties: "ApplicationUser")
            .GetAwaiter().GetResult().ToList();
        var instructorInfoDtos = _mapper.Map<List<InstructorInfoDTO>>(instructors);
        var fileName = await _closedXmlService.ExportInstructorExcel(instructorInfoDtos);

        // Send signal to user after finish export excel
        await _notificationHub.Clients.User(userId).SendAsync("DownloadExcelNow", fileName);

        return new ResponseDTO()
        {
            Message = "Waiting...",
            IsSuccess = true,
            StatusCode = 200,
            Result = null
        };
    }

    public async Task<ClosedXMLResponseDTO> DownloadInstructors(string fileName)
    {
        try
        {
            string filePath = Path.Combine(_env.ContentRootPath, _config["FolderPath:ExcelExportFolderPath"], fileName);

            if (!File.Exists(filePath))
            {
                return new ClosedXMLResponseDTO()
                {
                    Message = "File was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Stream = null,
                    ContentType = null,
                    FileName = null,
                };
            }

            // Đọc file vào memory stream
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }

            memory.Position = 0;
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            // Delete the file after user download it
            System.IO.File.Delete(filePath);

            return new ClosedXMLResponseDTO()
            {
                Stream = memory,
                ContentType = contentType,
                FileName = fileName,
                StatusCode = 200,
                IsSuccess = true,
                Message = "Download file successfully"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}