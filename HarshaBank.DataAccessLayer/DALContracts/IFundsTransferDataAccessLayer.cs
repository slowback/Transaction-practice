using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer;

public interface IFundsTransferDataAccessLayer
{
  public List<FundsTransfer> GetTransactions();

  public List<FundsTransfer> GetTransactionsByCondition(Predicate<FundsTransfer> predicate);

  public Guid Transfer(Account sourceAccount, Account destinationAccount, decimal amount);






}
