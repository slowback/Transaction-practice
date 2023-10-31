using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.DataAccessLayer.DALContracts;

namespace HarshaBank.DataAccessLayer;

public class FundsTransferDataAccessLayer : IFundsTransferDataAccessLayer
{
  #region Fields
  private static List<FundsTransfer>? _fundsTransferList;
  #endregion

  #region Constructors
  static FundsTransferDataAccessLayer()
  {
    _fundsTransferList = new List<FundsTransfer>();
  }
  #endregion

  #region Properties
  private static List<FundsTransfer> FundsTransfers
  {
    get => _fundsTransferList ?? new List<FundsTransfer>();
    set
    {
      _fundsTransferList = value;
    }
  }
  #endregion

  #region Methods
  /// <summary>
  /// Returns all existing fundsTransferList
  /// </summary>
  /// <returns></returns>
  public List<FundsTransfer> GetTransactions()
  {
    try
    {
      // Create a new customers list
      List<FundsTransfer> fundsTransfers = new();

      // copy all customers from the source collection into the newCustomers list
      FundsTransfers.ForEach(item => fundsTransfers.Add(item.Clone() as FundsTransfer ?? new FundsTransfer()));
      return fundsTransfers;
    }
    catch (FundsTransferException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  /// <summary>
  /// Returns list of FundTransfer that are matching with specified criteria.
  /// </summary>
  /// <param name="predicate">Labmda expression with condition</param>
  /// <returns>List of matching funds transfer</returns>
  public List<FundsTransfer> GetTransactionsByCondition(Predicate<FundsTransfer> predicate)
  {
    try
    {
      // Create a new customers list
      List<FundsTransfer> customersList = new();

      // Filter the collection
      List<FundsTransfer> filterfundsTransfer = FundsTransfers.FindAll(predicate);

      // copy all customers from the source collection into the newCustomers list
      filterfundsTransfer.ForEach(item => customersList.Add(item.Clone() as FundsTransfer ?? new FundsTransfer()));
      return filterfundsTransfer;
    }
    catch (FundsTransferException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

/// <summary>
/// Funds transfer between source account and destination account.
/// </summary>
/// <param name="sourceAccount">Source account</param>
/// <param name="destinationAccount">Destination account</param>
/// <param name="amount">Amount transferred.</param>
/// <returns>GUID transaction</returns>
/// <exception cref="InvalidOperationException"></exception>
  public Guid Transfer(Account sourceAccount, Account destinationAccount, decimal amount)
  {
    try
    {
      IAccountsDataAccessLayer accountsDataAccessLayer = new AccountsDataAccessLayer();
      FundsTransfer newTransaction = new()
      {
        TransferID = Guid.NewGuid(),
        DateTime = DateTime.Now,
        SourceAccountNumber = sourceAccount.AccountNumber,
        DestinationAccountNumber = destinationAccount.AccountNumber
      };

      sourceAccount.Balance -= amount;
      destinationAccount.Balance += amount;

      //- Update sourceAccount, destinationAccount.
      accountsDataAccessLayer.UpdateAccount(sourceAccount);
      accountsDataAccessLayer.UpdateAccount(destinationAccount);

      newTransaction.Amount = amount;
      FundsTransfers.Add(newTransaction);

      return newTransaction.TransferID;
    }
    catch (FundsTransferException ex)
    {
      throw new InvalidOperationException(ex.Message);
    }
    catch (Exception)
    {
      throw;
    }
  }
  #endregion
}
