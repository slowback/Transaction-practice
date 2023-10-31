using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;

namespace HashaBank.Presentation;

public static class AccountsPresentation
{
  internal static void AddAccount()
  {
    try
    {
      // Create an object Account 
      Account account = new();
      Customer? foundCustomer = null;

      // Create BL object
      Console.WriteLine("\n******* ADD ACCOUNT *******");

      ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
      IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

      List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
      Console.WriteLine("\n******** ALL CUSTOMERS ********");
      CustomersPresentation.PrintAllCustomer(allCustomers);

      Console.Write("\nEnter the Customer Code for which you want to create a new account: ");
      long customerCode = long.Parse(Console.ReadLine() ?? "");

      foreach (var cus in allCustomers)
      {
        if (cus.CustomerCode == customerCode)
        {
          foundCustomer = cus;
          break;
        }
      }
      if (foundCustomer is not null)
      {
        account.CustomerCode = foundCustomer.CustomerCode;
        account.CustomerName = foundCustomer.CustomerName;
        Guid guid = accountsBusinessLogicLayer.AddAccount(account);
        Console.WriteLine(guid);
        Console.WriteLine("New Account Number: " + account.AccountNumber);
        Console.WriteLine("Customer Added.\n");
      }
      else
      {
        Console.WriteLine("Customer Not added");
      }

    }
    catch (CustomerException ex)
    {
      Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      Console.WriteLine(ex.GetType());
    }

  }
  internal static void ViewAccount()
  {
    try
    {
      // Create BL object
      IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
      List<Account> allAccount = accountsBusinessLogicLayer.GetAccounts();
      Console.WriteLine("\n******** ALL ACCOUNTS ********");
      PrintAllAccount(allAccount);
    }
    catch (CustomerException)
    {
      throw;
    }

  }
  internal static void UpdateAccount()
  {
    Account? accountSelected;
    Customer? customerSelected;
    long selectAccountNumber;
    List<long> allAccountNumber;

    Console.WriteLine("\n******* EDIT ACCOUNT *******");
    IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
    ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
    List<Account> allAccount = accountsBusinessLogicLayer.GetAccounts();

    Console.WriteLine("\n******** ALL ACCOUNTS ********");
    PrintAllAccount(allAccount);

    allAccountNumber = allAccount.Select(account => account.AccountNumber).ToList();
    Console.Write("Enter the Account Number that you want to edit: ");
    selectAccountNumber = long.Parse(Console.ReadLine() ?? "");

    //- Check input from user exist in accoutNumber or not.
    if (allAccountNumber.Find(accountNumber => accountNumber == selectAccountNumber) > 0)
    {
      List<Customer> customers = customersBusinessLogicLayer.GetCustomers();
      accountSelected = allAccount.Find(acc => acc.AccountNumber == selectAccountNumber);
      customerSelected = customers.Find(cus => cus.CustomerCode == accountSelected?.CustomerCode);

      if (customerSelected is not null && accountSelected is not null)
      {
        CustomersPresentation.PrintAllCustomer(customerSelected);

        Console.Write("\nEnter the Updated (existing) Customer Code: ");
        long cusCode = long.Parse(Console.ReadLine() ?? "");

        Console.Write("new Balance: ");
        decimal newBalance = decimal.Parse(Console.ReadLine() ?? "");
        //- Updated
        accountSelected.Balance = newBalance;

        bool isUpdated = accountsBusinessLogicLayer.UpdateAccount(accountSelected);

        if (isUpdated)
        {
          Console.WriteLine("Account updated");
        }
        else
        {
          Console.WriteLine("Account not updated");
        }
      }
    }
    else
    {
      Console.WriteLine("Account number Invalid");
    }
  }
  internal static void DeleteAccount()
  {
    Console.WriteLine("\n******* DELETE *******");

    IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
    List<Account> accounts = accountsBusinessLogicLayer.GetAccounts();
    PrintAllAccount(accounts);

    Console.Write("Enter Account Number: ");
    long accNumber = long.Parse(Console.ReadLine() ?? "");
    Account? foundAccount = accounts.Find(acc => acc.AccountNumber == accNumber);

    if (foundAccount is not null)
    {
      Console.WriteLine("\n******** ACCOUNT ********");

      string? confirmDelete;

      Console.Write("Confirm Delete(yes or no): ");
      confirmDelete = Console.ReadLine();
      if (confirmDelete?.ToLower() == "yes")
      {
        //----- For test ----
        // bool deleted = customersBusinessLogicLayer.DeleteCustomer(Guid.NewGuid());

        bool deleted = accountsBusinessLogicLayer.DeleteAccount(foundAccount.AccountID);

        if (deleted)
        {
          Console.WriteLine("\nAccount deleted successfully");
        }
        else
        {
          Console.WriteLine("\nAccount not deleted successfully");
        }
      }
    }
    else
    {
      Console.WriteLine($"Account number {accNumber} not found");
    }

  }

  private static void PrintAllAccount(Account account)
  {
    Console.WriteLine("Account Number: " + account.AccountNumber);
    Console.WriteLine("Customer Code: " + account.CustomerCode);
    Console.WriteLine("Customer Name: " + account.CustomerName);
    Console.WriteLine("Balance: " + account.Balance);
    Console.WriteLine();
  }

  public static void PrintAllAccount(List<Account> accounts)
  {
    foreach (var item in accounts)
    {
      Console.WriteLine("Account Number: " + item.AccountNumber);
      Console.WriteLine("Customer Code: " + item.CustomerCode);
      Console.WriteLine("Customer Name: " + item.CustomerName);
      Console.WriteLine("Balance: " + item.Balance);
      Console.WriteLine();
    }
  }

}
