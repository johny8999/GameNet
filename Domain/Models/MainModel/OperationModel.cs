namespace Domain.Models.MainModel;

public class OperationModel:BaseModel
{
  public bool Is_Completed { get; set; }
    public decimal OEE { get; set; }
    public decimal Availabilit { get; set; }
    public decimal Performance { get; set; }
    public decimal Quality { get; set; }
}
