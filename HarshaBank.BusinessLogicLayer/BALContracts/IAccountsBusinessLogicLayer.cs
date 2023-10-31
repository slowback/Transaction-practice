using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer;

public interface IAccountsBusinessLogicLayer
{
  /// <summary>
  /// Return all existing accounts.
  /// </summary>
  /// <returns></returns>
  List<Account> GetAccounts();

  /// <summary>
  /// Return a set of accounts that matches with specified criteria.
  /// </summary>
  /// <param name="predicate">Lambda expression that contains condition to check</param>
  /// <returns>The list of matching accounts.</returns>
  List<Account> GetAccountsByCondition(Predicate<Account> predicate);

  /// <summary>
  /// Adds a new account to existing account list.
  /// </summary>
  /// <param name="account">The account object to add.</param>
  /// <returns>Account Number.</returns>
  Guid AddAccount(Account account);

  /// <summary>
  /// Update an existing account.
  /// </summary>
  /// <param name="account">Account object that contains account details to update</param>
  /// <returns>Return true, that indicates the account is updated successfully</returns>
  bool UpdateAccount(Account account);

  /// <summary>
  /// Deleted an existing account.
  /// </summary>
  /// <param name="accountID">AccountID to delete</param>
  /// <returns>Return true, that indicates the account is deleted successfully</returns>
  bool DeleteAccount(Guid accountID);

}
