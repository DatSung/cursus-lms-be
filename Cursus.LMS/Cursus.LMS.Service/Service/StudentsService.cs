﻿using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Service.Service
{
    public class StudentsService : IStudentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

                    var paymentCard = await _unitOfWork.PaymentCardRepository.GetCardByUserId(student.UserId);

                    StudentFullInfoDTO studentFullInfoDto = new StudentFullInfoDTO()
                    {
                        StudentId = student.StudentId,
                        UserId = student.UserId,
                        AvatarUrl = student.ApplicationUser.AvatarUrl,
                        FullName =  student.ApplicationUser.FullName,
                        University = student.University,
                        Email = student.ApplicationUser.Email,
                        Address = student.ApplicationUser.Address,
                        BirthDate = student.ApplicationUser.BirthDate,
                        Country = student.ApplicationUser.Country,
                        Gender = student.ApplicationUser.Gender,
                        PhoneNumber = student.ApplicationUser.PhoneNumber,
                        CardName = paymentCard?.CardName,
                        CardNumber = paymentCard?.CardNumber,
                        CardProvider = paymentCard?.CardProvider
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

        public Task<ResponseDTO> GetStudentPayoutMoney(Guid studentId)
        {
            throw new NotImplementedException();
        }

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

                var courses = await _unitOfWork.StudentCourseRepository.GetAllAsync(c => c.StudentId == id.StudentId);

                var totalCourses = courses.Count();
                if(totalCourses == 0)
                {
                    return new ResponseDTO()
                    {
                        Message = "Student has not registered for any courses",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 400
                    };
                }

                return new ResponseDTO()
                {
                    Message = "Get Course Successfull",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = totalCourses
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

        public Task<ResponseDTO> GetAllStudentComment(Guid studentId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO> CreateStudentComment(ClaimsPrincipal User, CreateStudentCommentDTO createStudentCommentDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> UpdateStudentComment(ClaimsPrincipal User, UpdateStudentCommentDTO updateStudentCommentDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> DeleteStudentComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Task<ClosedXMLResponseDTO> DownloadStudents(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> ExportStudents(string userId, int month, int year)
        {
            throw new NotImplementedException();
        }


    }
}
