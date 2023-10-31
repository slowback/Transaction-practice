using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.DataAccessLayer;

namespace HarshaBank.BusinessLogicLayer;

public class FundsTransferBusinessLogicLayer : IFundsTransferBusinessLogicLayer
{
  #region Private Fields
  private IFundsTransferDataAccessLayer _fundsTransferDataAccessLayer;
  #endregion

  #region Constructors
  public FundsTransferBusinessLogicLayer()
  {
    _fundsTransferDataAccessLayer = new FundsTransferDataAccessLayer();
  }
  #endregion

  #region Properties
  private IFundsTransferDataAccessLayer FundsTransferDataAccessLayer
  {
    get => _fundsTransferDataAccessLayer;
    set => _fundsTransferDataAccessLayer = value;
  }
  #endregion

  #region Methods
  public List<FundsTransfer> GetTransactions()
  {
    try
    {
      return FundsTransferDataAccessLayer.GetTransactions();
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

  public List<FundsTransfer> GetTransactionsByCondition(Predicate<FundsTransfer> predicate)
  {
    try
    {
      // invoke DAL
      return FundsTransferDataAccessLayer.GetTransactionsByCondition(predicate);
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

  public Guid Transfer(Account sourceAccount, Account destinationAccount, decimal amount)
  {
    try
    {
      return FundsTransferDataAccessLayer.Transfer(sourceAccount, destinationAccount, amount);
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

  public bool UpdateAccount(Account account)
  {
    throw new NotImplementedException();
  }
  #endregion
}
