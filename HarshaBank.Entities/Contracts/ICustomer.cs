/// <summary>
/// Represents interface of customer entity.
/// </summery>
namespace HarshaBank.Entities.Contracts;

public interface ICustomer
{
  #region Properties
  Guid CustomerID { get; set; }
  long CustomerCode { get; set; }
  string? CustomerName { get; set; }
  string? Address { get; set; }
  string? City { get; set; }
  string? Country { get; set; }
  string? Mobile { get; set; }
  #endregion

  

}
