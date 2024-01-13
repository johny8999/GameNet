namespace Application.Dto.Production.Response;

public sealed class GetProductionByDayResponseDto
{
  public decimal Quantity { get; set; }
  public decimal QuantityPlan { get; set; }
  public string End_Product { get; set; }
}
