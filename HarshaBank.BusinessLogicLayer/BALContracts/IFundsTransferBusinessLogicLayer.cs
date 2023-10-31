using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer.BALContracts;

public interface IFundsTransferBusinessLogicLayer
{
  public List<FundsTransfer> GetTransactions();

  public List<FundsTransfer> GetTransactionsByCondition(Predicate<FundsTransfer> predicate);

  public Guid Transfer(Account sourceAccount, Account destinationAccount, decimal amount);
}
