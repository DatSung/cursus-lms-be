using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Cursus.LMS.Service.Service;

public class LevelService : ILevelService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public LevelService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetLevels
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 0,
        int pageSize = 0
    )
    {
        try
        {
            // Lấy role xem có phải admin không
            var userRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            IEnumerable<Level> levels;

            if (userRole == StaticUserRoles.Admin)
            {
                // Lấy tất cả các bình luận của phiên bản khóa học theo courseVersionId
                levels = await _unitOfWork.LevelRepository.GetAllAsync();
            }
            else
            {
                // Lấy các bình luận với trạng thái Activated hoặc thấp hơn
                levels = await _unitOfWork.LevelRepository.GetAllAsync(x => x.Status <= 1);
            }

            // Kiểm tra nếu danh sách bình luận là null hoặc rỗng
            if (!levels.Any())
            {
                return new ResponseDTO()
                {
                    Message = "There are no levels",
                    IsSuccess = true,
                    StatusCode = 404,
                    Result = null
                };
            }

            var listLevels = levels.ToList();

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "name":
                        listLevels = listLevels.Where(x =>
                            x.Name.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    default:
                        break;
                }
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "name":
                        listLevels = listLevels.OrderBy(x => x.Name).ToList();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // Sắp xếp bình luận theo thời gian tạo giảm dần nếu không có sortBy được chỉ định
                listLevels = listLevels.OrderByDescending(x => x.CreatedTime).ToList();
            }

            // Phân trang
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                listLevels = listLevels.Skip(skipResult).Take(pageSize).ToList();
            }

            // Chuyển đổi danh sách bình luận thành DTO
            var levelsDto = listLevels.Select(level => new GetLevelDTO()
            {
                Id = level.Id,
                Name = level.Name,
                CreateTime = level.CreatedTime,
                CreateBy = level.CreatedBy,
                UpdateTime = level.UpdatedTime,
                UpdateBy = level.UpdatedBy,
                Status = level.Status
            }).ToList();

            return new ResponseDTO()
            {
                Message = "Get levels successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = levelsDto
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

    public async Task<ResponseDTO> GetLevel(ClaimsPrincipal User, Guid levelId)
    {
        try
        {
            var LevelID =
                await _unitOfWork.LevelRepository.GetLevelById(levelId);

            if (LevelID is null)
            {
                return new ResponseDTO()
                {
                    Result = "",
                    Message = "Level was not found",
                    IsSuccess = true,
                    StatusCode = 404
                };
            }

            GetLevelDTO levelDto;
            try
            {
                levelDto = _mapper.Map<GetLevelDTO>(LevelID);
            }
            catch (AutoMapperMappingException e)
            {
                // Log the mapping error
                // Consider logging e.Message or e.InnerException for more details
                return new ResponseDTO()
                {
                    Result = null,
                    Message = "Failed to map Level to GetLevelDTO",
                    IsSuccess = false,
                    StatusCode = 500
                };
            }

            return new ResponseDTO()
            {
                Result = levelDto,
                Message = "Get level successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Result = null,
                Message = e.Message,
                IsSuccess = true,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> CreateLevel(ClaimsPrincipal User, CreateLevelDTO createLevelDto)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            //Map DTO qua entity Level
            Level levels = new Level()
            {
                Name = createLevelDto.Name,
                CreatedBy = admin.Email,
                CreatedTime = DateTime.Now,
                UpdatedTime = null,
                UpdatedBy = "",
                Status = 0
            };

            //thêm level mới
            await _unitOfWork.LevelRepository.AddAsync(levels);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Level created successfully",
                Result = levels,
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

    public async Task<ResponseDTO> UpdateLevel(ClaimsPrincipal User, UpdateLevelDTO updateLevelDto)
    {
        try
        {
            // kiểm tra xem có ID trong database không
            var levelID = await _unitOfWork.LevelRepository.GetAsync(c => c.Id == updateLevelDto.LevelId);

            // kiểm tra xem có null không
            if (levelID == null)
            {
                return new ResponseDTO
                {
                    Message = "Level not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            // cập nhật thông tin danh mục
            levelID.Name = updateLevelDto.Name;
            levelID.UpdatedTime = DateTime.Now;
            levelID.UpdatedBy = User.Identity.Name;
            levelID.Status = 1;


            // thay đổi dữ liệu
            _unitOfWork.LevelRepository.Update(levelID);

            // lưu thay đổi vào cơ sở dữ liệu
            var save = await _unitOfWork.SaveAsync();
            if (save <= 0)
            {
                return new ResponseDTO
                {
                    Message = "Failed to update level",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            return new ResponseDTO
            {
                Message = "Level updated successfully",
                Result = levelID,
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


    public async Task<ResponseDTO> DeleteLevel(ClaimsPrincipal User, Guid levelId)
    {
        try
        {
            // kiểm tra xem có ID trong database không
            var levelID = await _unitOfWork.LevelRepository.GetAsync(c => c.Id == levelId);

            if (levelID == null)
            {
                return new ResponseDTO
                {
                    Message = "Delete level successfully",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            levelID.Status = 2;
            levelID.UpdatedBy = User.Identity.Name;
            levelID.UpdatedTime = DateTime.Now;

            _unitOfWork.LevelRepository.Update(levelID);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Level updated successfully",
                Result = levelID,
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
}
