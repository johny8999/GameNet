namespace Application.Dto.Production.Request;

public sealed class GetProductionByHoursRequestDto
{
  public decimal Quantity { get; set; }
  public decimal Quantity_Plan { get; set; }
  public string End_Product { get; set; }
}
