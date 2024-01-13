using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class Production : BaseModel
{
  public int? Plants_Code { get; set; }
  public string? WorkCenter_Code { get; set; }
  public int? Order_Code { get; set; }
  public DateTime? Start_Product { get; set; }
  public DateTime End_Product { get; set; }
  public string? Event_Type { get; set; }
  public TimeSpan? Ideal_Cycle { get; set; }
  public TimeSpan? Real_Cycle { get; set; }
  public int? part_per_cycle { get; set; }
  public decimal? Quantity { get; set; }
  public decimal? QuantityPlan { get; set; }
  public string? Reason { get; set; }
  public string? Comment { get; set; }
  public int? Pallet_Code { get; set; }
  public bool? is_plan { get; set; }
  public bool? Cycle_is_more { get; set; }
  public bool? Cycle_is_less { get; set; }
  public TimeSpan? Cycle_more { get; set; }
  public TimeSpan? Cycle_less { get; set; }
  public string? GroupReason { get; set; }
}
