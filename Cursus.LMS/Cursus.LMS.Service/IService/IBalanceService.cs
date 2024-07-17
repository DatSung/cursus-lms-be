using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IBalanceService
{
    Task<ResponseDTO> UpSertBalance(UpSertBalanceDTO upSertBalanceDto);
}