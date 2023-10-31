using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer;

/// <summary>
/// Interface for representes Account data access layer
/// </summary>
public interface IAccountsDataAccessLayer
{
  /// <summary>
  /// Return all existing accounts
  /// </summary>
  /// <returns></returns>
  public List<Account> GetAccounts();

  /// <summary>
  /// Return a set of Account that matches with specified criteria.
  /// </summary>
  /// <param name="predicate"></param>
  /// <returns></returns>
  public List<Account> GetAccountByCondition(Predicate<Account> predicate);

  /// <summary>
  /// Adds a new account to existing account list.
  /// </summary>
  /// <param name="account"></param>
  /// <returns>Account Number</returns>
  public Guid AddAccount(Account account);

  /// <summary>
  /// Update an existing account.
  /// </summary>
  /// <param name="account"></param>
  /// <returns></returns>
  public bool UpdateAccount(Account account);

  /// <summary>
  /// Deleted an edisting account.
  /// </summary>
  /// <param name="account"></param>
  /// <returns></returns>
  public bool DeleteAccount(Guid accountID);

}
