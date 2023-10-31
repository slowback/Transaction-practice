/// <summary>
/// Represents account of the bank
/// <summary>
using HarshaBank.Exceptions;
using HarshaBank.Entities.Contracts;

namespace HarshaBank.Entities;

public class Account : IAccount, ICloneable
{
  #region Private fields
  private Guid _accountID;
  private long _accountNumber;
  private long _customerCode;
  private string? _customerName;
  private decimal _balance = 0.0M;
  #endregion

  //- Properties
  #region Public Properties
  /// <summary>
  /// Guid of account for unique identification.
  /// </summary>
  public Guid AccountID { get => _accountID; set => _accountID = value; }
  /// <summary>
  /// Auto-generated code number of the account
  /// </summary>
  public long AccountNumber { get => _accountNumber; set => _accountNumber = value; }

  /// <summary>
  /// Number of customer code, auto-create from customer class.
  /// </summary>
  public long CustomerCode
  {
    get => _customerCode;
    set
    {
      if (value > 0)
        _customerCode = value;
      else
        throw new CustomerException("Customer code must be greater than zero");
    }
  }

  /// <summary>
  /// Name of the customer, auto-create from customer class.
  /// </summary>
  public string? CustomerName
  {
    get => _customerName;
    set
    {
      _customerName = value;
    }
  }
  /// <summary>
  /// Balance transection of customer.
  /// </summary>
  public decimal Balance
  {
    get => _balance;
    set => _balance = value;
  }

  public object Clone()
  {
    return new Account()
    {
      AccountID = this.AccountID,
      AccountNumber = this.AccountNumber,
      CustomerCode = this.CustomerCode,
      CustomerName = this.CustomerName,
      Balance = this.Balance,
    };
  }
  #endregion


}
