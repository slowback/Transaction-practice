using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;

namespace HashaBank.Presentation;

public static class DisplayAccountStatementPresentation
{
  internal static void Display()
  {
    IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
    List<Account> accounts = accountsBusinessLogicLayer.GetAccounts();

    Console.WriteLine("\n******* ACCOUNT STATEMENT *******");
    Console.WriteLine("\n******* ALL ACCOUNTS *******");
    AccountsPresentation.PrintAllAccount(accounts);

    Console.Write("Enter the Account Number that you want to view: ");
    long seletedAccountNumber = long.Parse(Console.ReadLine() ?? "");
    List<Account> foundAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(acc => acc.AccountNumber == seletedAccountNumber);

    if (foundAccounts.Count == 1)
    {
      IFundsTransferBusinessLogicLayer fundsTransferBusinessLogicLayer = new FundsTransferBusinessLogicLayer();
      List<FundsTransfer> foundFundsTransfers = fundsTransferBusinessLogicLayer.GetTransactionsByCondition(transfer => transfer.SourceAccountNumber == foundAccounts[0].AccountNumber);
      Console.WriteLine("foundFundsTransfers: " + foundFundsTransfers.Count());

      Console.WriteLine("\nDebit Transactions: ");
      if (foundFundsTransfers.Count == 1)
      {
        FundsTransferPresentation.PrintTransfer(foundFundsTransfers[0]);
      }
      else if (foundFundsTransfers.Count > 1)
      {
        FundsTransferPresentation.PrintAllTransfer(foundFundsTransfers);
      }
      else
      {
        Console.WriteLine("No Transactions");
      }
    }
    else if (foundAccounts.Count > 1)
    {
      throw new AccountException("Account Number duplicated.");
    }
    else
    {
      Console.WriteLine("Not Found Account Number");
    }
  }
}
