using System;
using Domain.Models.MainModel;

namespace Domain.Models.OperationTables;

public class Order_Operation : OperationModel
{
    public int? Plants_Code { get; set; }
    public string? WorkCenter_Code { get; set; }
    public int? Order_Code { get; set; }
    public DateTime? Register_Date { get; set; }
    public DateTime? Complete_Date { get; set; }
    public decimal? Order_Requested_Qty { get; set; }
    public decimal? Order_Completed_Qty { get; set; }
    public decimal? Order_Remained_Qty { get; set; }
    public TimeSpan? Order_ETC_Min { get; set; }
    public TimeSpan? Order_ETC_Max { get; set; }
    public DateTime? Order_Last_Start_Date { get; set; }
    public DateTime? Order_Last_Stop_Date { get; set; }
    public TimeSpan? Part_Ideal_Cycle { get; set; }
    public TimeSpan? Part_Real_Cycle { get; set; }
    public decimal? Part_Per_Cycle { get; set; }
    public DateTime? Analyze_Last_Update { get; set; }

}