using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IPaymentService
{
    Task<ResponseDTO> UpdateBalanceByOrderId(Guid orderHeaderId);
}