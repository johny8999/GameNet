using System;
using Domain.Models.MainModel;

namespace Domain.Models.OperationTables;

public class WorkCenter_Operation:OperationModel
{
    public int? Plants_Code { get; set; }
    public string? WorkCenter_Code { get; set; }
    public int? Order_Code { get; set; }
    public DateTime? Register_Date { get; set; }
    public DateTime? Complete_Date { get; set; }
    public DateTime? Analyze_Last_Update { get; set; }
    
}