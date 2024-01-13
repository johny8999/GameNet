namespace Application.Dto.PalletOperation.Response;

public sealed class GetPalletOperationByInputCountResponseDto
{
    public long ID { get; set; }
    public decimal Availabilit { get; set; }
    public decimal Performance { get; set; }
    public decimal Quality { get; set; }
    public decimal OEE { get; set; }   
}