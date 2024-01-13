using System;
using Domain.Models.MainModel;

namespace Domain.Models.OperationTables;

public class Shift_Operation:OperationModel
{
    public int? Plants_Code { get; set; }
    public string? WorkCenter_Code { get; set; }
    public int? Order_Code { get; set; }
    public int? Shift_Code { get; set; }
    public DateTime? Start_Shift { get; set; }
    public DateTime End_Shift { get; set; }
    public decimal Register_Date { get; set; }
    public DateTime Complete_Date { get; set; }
    public DateTime Analyze_Last_Update { get; set; }
}