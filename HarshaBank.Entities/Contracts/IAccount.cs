/// <summary>
/// Represents interface of account entity.
/// </summary>

namespace HarshaBank.Entities.Contracts;

public interface IAccount
{
  #region Properties
  Guid AccountID { get; set; }
  long CustomerCode { get; set; }
  string? CustomerName { get; set; }
  decimal Balance { get; set; }
  #endregion

}
