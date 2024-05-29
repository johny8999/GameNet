using Application.Dto.CustomerAccounting.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Template.Controllers;

public class CustomerAccountingController(ICustomerAccountingApplication service) : ControllerBase
{
  [HttpPost("[action]")]
  public async Task<IActionResult> AddCustomerAccount([FromBody] AddCustomerAccountingDto input)
  {
    var result = await service.AddCustomerAccountingAsync(input);
    return StatusCode(result.StatusCode, result);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> AddCustomerAccountByTime([FromBody] AddCustomerAccountByTimeDto input)
  {
    var result = await service.AddCustomerAccountByTimeAsync(input);
    return StatusCode(result.StatusCode, result);
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> SelectUserPurchaseByDateAsync([FromQuery] SelectUserPurchaseByDateDto input)
  {
    var result = await service.SelectUserPurchaseByDateAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
