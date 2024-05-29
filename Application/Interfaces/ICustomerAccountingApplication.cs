using Application.Common.Statics;
using Application.Dto.CustomerAccounting.Request;

namespace Application.Interfaces;

public interface ICustomerAccountingApplication
{
  Task<ResponseDto> AddCustomerAccountingAsync(AddCustomerAccountingDto input);
  Task<ResponseDto> AddCustomerAccountByTimeAsync(AddCustomerAccountByTimeDto input);
  Task<ResponseDto> SelectUserPurchaseByDateAsync(SelectUserPurchaseByDateDto input);
}
