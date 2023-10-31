using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;

namespace HashaBank.Presentation;

public static class FundsTransferPresentation
{
  internal static void Transfer()
  {
    try
    {
      Console.WriteLine("\n******* ACCOUNT STATEMENT *******");
      IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
      IFundsTransferBusinessLogicLayer fundsTransferBusinessLogicLayer = new FundsTransferBusinessLogicLayer();
      List<Account> accounts = accountsBusinessLogicLayer.GetAccounts();
      decimal sourceAccountSeleted, destinationSeleted, amount;
      Account? foundSourceAccount;
      Account? foundDestinationAccount;
      bool isValidAmount;

      Console.WriteLine("\n******* ALL ACCOUNTS *******");
      AccountsPresentation.PrintAllAccount(accounts);

      Console.Write("\nEnter the Source Account Number: ");
      sourceAccountSeleted = long.Parse(Console.ReadLine() ?? "");
      Console.Write("\nEnter the Destination Account Number: ");
      destinationSeleted = long.Parse(Console.ReadLine() ?? "");
      Console.Write("\nAmount: ");
      amount = decimal.Parse(Console.ReadLine() ?? "");

      foundSourceAccount = accounts.Find(acc => acc.AccountNumber == sourceAccountSeleted);
      foundDestinationAccount = accounts.Find(acc => acc.AccountNumber == destinationSeleted);

      if ((foundSourceAccount is not null) && (foundDestinationAccount is not null))
      {
        isValidAmount = foundSourceAccount?.Balance >= amount;
        if (isValidAmount)
        {
          fundsTransferBusinessLogicLayer.Transfer(foundSourceAccount ?? new Account(), foundDestinationAccount, amount);
          Console.WriteLine("\nTransaction successful.");
          List<Account>? sourceAcc = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == foundSourceAccount?.AccountNumber);
          List<Account>? destinationAcc = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == foundDestinationAccount?.AccountNumber);

          if (sourceAcc.Count > 1 || destinationAcc.Count > 1)
          {
            throw new AccountException("Error, Multiple account");
          }
          else
          {
            Console.WriteLine($"Account Balance of source account number {sourceAcc[0].AccountNumber} is {sourceAcc[0].Balance}");
            Console.WriteLine($"Account Balance of destination account number {destinationAcc[0].AccountNumber} is {destinationAcc[0].Balance}");
          }
        }
        else
        {
          Console.WriteLine("\nSource Account balance not enough.");
        }
      }
      else
      {
        Console.WriteLine("Account Number Invalid, Please check source account or destination account.");
      }
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

  public static void PrintAllTransfer(List<FundsTransfer> transfers)
  {
    foreach (FundsTransfer transfer in transfers)
    {
      Console.WriteLine("Transaction Date: " + transfer.DateTime);
      Console.WriteLine("Source Accont Number: " + transfer.SourceAccountNumber);
      Console.WriteLine("Destination Accont Number: " + transfer.DestinationAccountNumber);
      Console.WriteLine("Amount: " + transfer.Amount);
      Console.WriteLine();
    }

  }

  public static void PrintTransfer(FundsTransfer transfer)
  {
    Console.WriteLine("Transaction Date: " + transfer.DateTime);
    Console.WriteLine("Source Accont Number: " + transfer.SourceAccountNumber);
    Console.WriteLine("Destination Accont Number: " + transfer.DestinationAccountNumber);
    Console.WriteLine("Amount: " + transfer.Amount);
    Console.WriteLine();
  }
}
