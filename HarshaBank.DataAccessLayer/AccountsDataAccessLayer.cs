using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.DataAccessLayer.DALContracts;

namespace HarshaBank.DataAccessLayer;

public class AccountsDataAccessLayer : IAccountsDataAccessLayer
{
  #region Fields
  private static List<Account>? _accounts;
  #endregion

  #region Constructors
  static AccountsDataAccessLayer()
  {
    _accounts = new List<Account>();
  }
  #endregion

  #region Properties
  /// <summary>
  /// Represents source account collection.
  /// </summary>
  private static List<Account> Accounts
  {
    get => _accounts ?? new List<Account>();
    set
    {
      _accounts = value;
    }
  }
  #endregion

  #region Methods
  /// <summary>
  /// Adds a new account to the existing account list.
  /// </summary>
  /// <param name="account">Account object to add</param>
  /// <returns>Account Number.</returns>
  public Guid AddAccount(Account account)
  {
    try
    {
      account.AccountID = Guid.NewGuid();
      Accounts.Add(account);
      return account.AccountID;
    }
    catch (AccountException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  /// <summary>
  /// Deleted an existing account based on account number.
  /// </summary>
  /// <param name="accountID">AccountID to delete</param>
  /// <returns>true if deleted, otherwise unsuccess return false </returns>
  public bool DeleteAccount(Guid accountID)
  {
    try
    {
      if (Accounts.RemoveAll(item => item.AccountID == accountID) > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    catch (AccountException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  /// <summary>
  /// Returns list of accounts that are matching with specified criteria
  /// </summary>
  /// <param name="predicate">Lambda expression with condition</param>
  /// <returns>List of matcing accounts</returns>
  public List<Account> GetAccountByCondition(Predicate<Account> predicate)
  {
    try
    {
      // Create a new customers list
      List<Account> accountsList = new();

      // Filter the collection
      List<Account> filterAccounts = Accounts.FindAll(predicate);

      // copy all customers from the source collection into the newCustomers list
      filterAccounts.ForEach(item => accountsList.Add(item.Clone() as Account ?? new Account()));
      return filterAccounts;
    }
    catch (CustomerException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  /// <summary>
  /// Returns all existing accounts
  /// </summary>
  /// <returns>Accounts list</returns>
  public List<Account> GetAccounts()
  {
    try
    {
      // Create a new customers list
      List<Account> accountsList = new();

      // copy all customers from the source collection into the newCustomers list
      Accounts.ForEach(item => accountsList.Add(item.Clone() as Account ?? new Account()));
      return accountsList;
    }
    catch (CustomerException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  public bool UpdateAccount(Account account)
  {
    try
    {
      // Find existing customer by CustomerID
      Account? existingAccount = Accounts.Find(item => item.AccountID == account.AccountID);

      // Update all details of customer
      if (existingAccount != null)
      {
        existingAccount.AccountNumber = account.AccountNumber;
        existingAccount.CustomerCode = account.CustomerCode;
        existingAccount.CustomerName = account.CustomerName;
        existingAccount.Balance = account.Balance;
        return true;  // indicates that customers is updated
      }
      return false;

    }
    catch (CustomerException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }
  #endregion
}
