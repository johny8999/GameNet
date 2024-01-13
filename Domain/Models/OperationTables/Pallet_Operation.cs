using System;
using Domain.Models.MainModel;

namespace Domain.Models.OperationTables;

public class Pallet_Operation : OperationModel
{
    public int? Plants_Code { get; set; }
    public string? WorkCenter_Code { get; set; }
    public int? Order_Code { get; set; }
    public string? Shift_Name { get; set; }
    public DateTime? Shift_Start_Date { get; set; }
    public DateTime Shift_End_Date { get; set; }
    public int? Part_Code { get; set; }
    public int? Pallet_Code { get; set; }
    public int? User_Code1 { get; set; }
    public int? User_Code2 { get; set; }
    public int? User_Code3 { get; set; }
    public int? User_Code4 { get; set; }
    public int? User_Code5 { get; set; }
    public int? Label_Count { get; set; }
    public string? Label_URL { get; set; }
    public decimal? Auto_Quantity { get; set; }
    public decimal? Real_Quantity { get; set; }
    public DateTime? Register_Date { get; set; }
    public DateTime? Complete_Date { get; set; }
    public DateTime? Analyze_Last_Update { get; set; }
    public string? SAP_Serial { get; set; }
}