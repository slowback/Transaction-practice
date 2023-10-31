/// <summary>
/// Represents interface of Funds transfer entity.
/// <summary>
namespace HarshaBank.Entities.Contracts;

public interface IFundsTransfer
{

  #region Properties
  Guid TransferID { get; set; }
  DateTime DateTime { get; set; }

  long SourceAccountNumber { get; set; }
  long DestinationAccountNumber { get; set; }
  decimal Amount { get; set; }
  #endregion

}
