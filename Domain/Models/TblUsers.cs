using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class TblUsers : IdentityUser<Guid>
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string NationalCode { get; set; }

  public DateTime? LastTrySentSms { get; set; }

  public ICollection<TblCustomerAccounting> TblCustomerAccountings { get; set; }
  public ICollection<TblUserGameNet> TblUserGameNets { get; set; }
  public ICollection<TblDebt> TblDebts { get; set; }
}
