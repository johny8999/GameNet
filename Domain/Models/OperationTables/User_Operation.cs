using System;
using Domain.Models.MainModel;

namespace Domain.Models.OperationTables;

public class User_Operation : OperationModel
{
    public int? Plants_Code { get; set; }
    public string? WorkCenter_Code { get; set; }
    public int? Order_Code { get; set; }
    public int? User_Code { get; set; }
    public DateTime? login_Date { get; set; }
    public DateTime? logout_Date { get; set; }
    public decimal? Register_Date { get; set; }
    public decimal? Complete_Date { get; set; }
    public decimal? Analyze_Last_Update { get; set; }
}