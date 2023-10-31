using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.DataAccessLayer;

namespace HarshaBank.BusinessLogicLayer;

public class AccountsBusinessLogicLayer : IAccountsBusinessLogicLayer
{
  #region Private Fields
  private IAccountsDataAccessLayer _accountDataAccessLayer;
  #endregion

  #region Constructors
  public AccountsBusinessLogicLayer()
  {
    _accountDataAccessLayer = new AccountsDataAccessLayer();
  }
  #endregion

  #region Properties
  private IAccountsDataAccessLayer AccountsDataAccessLayer
  {
    get => _accountDataAccessLayer;
    set => _accountDataAccessLayer = value;
  }
  #endregion

  #region Methods

  public Guid AddAccount(Account account)
  {
    try
    {
      // get all customers
      List<Account> allAccount = AccountsDataAccessLayer.GetAccounts();
      long maxAccountNumber = 0;
      foreach (var item in allAccount)
      {
        if (item.AccountNumber > maxAccountNumber)
          maxAccountNumber = item.AccountNumber;
      }
      if (allAccount.Count >= 1)
      {
        account.AccountNumber = maxAccountNumber + 1;
      }
      else
      {
        account.AccountNumber = HarshaBank.Configuration.Settings.BaseAccountNo + 1;
      }
      return AccountsDataAccessLayer.AddAccount(account);
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

  public bool DeleteAccount(Guid accountID)
  {
    try
    {
      return AccountsDataAccessLayer.DeleteAccount(accountID);
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

  public List<Account> GetAccounts()
  {
    try
    {
      // invoke DAL
      return AccountsDataAccessLayer.GetAccounts();
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

  public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
  {
    try
    {
      // invoke DAL
      return AccountsDataAccessLayer.GetAccountByCondition(predicate);
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

  public bool UpdateAccount(Account account)
  {
    try
    {
      return AccountsDataAccessLayer.UpdateAccount(account);
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
  #endregion
}
