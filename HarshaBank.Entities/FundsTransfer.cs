using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;
namespace HarshaBank.Entities;

public class FundsTransfer : IFundsTransfer, ICloneable
{
  #region Private fields

  private Guid _transferID;
  private DateTime _dateTime;
  private long _sourceAccountNumber;
  private long _destinationAccountNumber;
  private decimal _amount;
  #endregion

  #region Public Properties
  /// <summary>
  /// GUID transaction.
  /// </summary>
  public Guid TransferID { get => _transferID; set => _transferID = value; }

  /// <summary>
  /// Date of Transaction
  /// </summary>
  public DateTime DateTime { get => _dateTime; set => _dateTime = value; }

  /// <summary>
  /// Source account transaction.
  /// </summary>
  public long SourceAccountNumber { get => _sourceAccountNumber; set => _sourceAccountNumber = value; }

  /// <summary>
  /// Destination account transaction.
  /// </summary>
  public long DestinationAccountNumber { get => _destinationAccountNumber; set => _destinationAccountNumber = value; }

  /// <summary>
  /// Amount of transaction.
  /// </summary>
  public decimal Amount
  {
    get => _amount;
    set
    {
      if (value > 0)
      {
        _amount = value;
      }
      else
      {
        throw new FundsTransferException("Transaction amount must be greater than zero");
      }
    }
  }

  public object Clone()
  {
    return new FundsTransfer()
    {
      TransferID = this.TransferID,
      DateTime = this.DateTime,
      SourceAccountNumber = this.SourceAccountNumber,
      DestinationAccountNumber = this.DestinationAccountNumber,
      Amount = this.Amount
    };
  }
  #endregion
}