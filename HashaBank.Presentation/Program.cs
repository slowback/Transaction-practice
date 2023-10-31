namespace HashaBank.Presentation;
class Program
{
  //Application execution starts here
  static void Main()
  {
    //display title
    System.Console.WriteLine("************** Harsha Bank *****************");
    System.Console.WriteLine("::Login Page::");

    //declare variables to store username and password;
    string? password = null;

    //read userName from keyboard
    System.Console.Write("Username: ");
    string? userName = System.Console.ReadLine();

    //read password from keyboard only if username is entered
    if (userName != "")
    {
      System.Console.Write("Password: ");
      password = System.Console.ReadLine();
    }

    //check username and password
    if (userName == "system" && password == "manager")
    {
      //declare variable to store menu choice
      int mainMenuChoice;
      do
      {
        //show main menu
        System.Console.WriteLine("\n:::Main menu:::");
        System.Console.WriteLine("1. Customers");
        System.Console.WriteLine("2. Accounts");
        System.Console.WriteLine("3. Funds Transfer");
        System.Console.WriteLine("4. Funds Transfer Statement");
        System.Console.WriteLine("5. Account Statement");
        System.Console.WriteLine("0. Exit");

        //accept menu choice from keyboard
        System.Console.Write("Enter choice: ");
        mainMenuChoice = int.Parse(System.Console.ReadLine() ?? "");

        //switch-case to check menu choice
        switch (mainMenuChoice)
        {
          case 1: CustomersMenu(); break;
          case 2: AccountsMenu(); break;
          case 3: FundsTransfer(); break;
          case 4: DisplayFundsTransferStatement(); break;
          case 5: DisplayAccountStatement(); break;
        }
      } while (mainMenuChoice != 0);
    }
    else
    {
      System.Console.WriteLine("Invalid username or password");
    }

    //about to exit
    System.Console.WriteLine("Thank you! Visit again.");
  }

  static void CustomersMenu()
  {
    //variable to store customers menu choice
    int customerMenuChoice = -1;

    //do-while loop starts
    do
    {
      //print customers menu
      System.Console.WriteLine("\n:::Customers menu:::");
      System.Console.WriteLine("1. Add Customer");
      System.Console.WriteLine("2. Delete Customer");
      System.Console.WriteLine("3. Update Customer");
      System.Console.WriteLine("4. Search Customers");
      System.Console.WriteLine("5. View Customers");
      System.Console.WriteLine("0. Back to Main Menu");

      //accept customers menu choice
      System.Console.Write("Enter choice: ");
      customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

      //switch case
      switch (customerMenuChoice)
      {
        case 1: CustomersPresentation.AddCustomer(); break;
        case 2: CustomersPresentation.DeleteCustomer(); break;
        case 3: CustomersPresentation.UpdateCustomer(); break;
        case 4: CustomersPresentation.Search(); break;
        case 5: CustomersPresentation.ViewCustomers(); break;
      }
    } while (customerMenuChoice != 0);
  }


  static void AccountsMenu()
  {
    //variable to store accounts menu choice
    int accountsMenuChoice;

    //do-while loop starts
    do
    {
      //print  accounts menu
      System.Console.WriteLine("\n:::Accounts menu:::");
      System.Console.WriteLine("1. Add Account");
      System.Console.WriteLine("2. Delete Account");
      System.Console.WriteLine("3. Update Account");
      System.Console.WriteLine("4. View Accounts");
      System.Console.WriteLine("0. Back to Main Menu");

      //accept accounts menu choice
      System.Console.Write("Enter choice: ");
      accountsMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

      switch (accountsMenuChoice)
      {
        case 1: AccountsPresentation.AddAccount(); break;
        case 2: AccountsPresentation.DeleteAccount(); break;
        case 3: AccountsPresentation.UpdateAccount(); break;
        case 4: AccountsPresentation.ViewAccount(); break;
      }
    } while (accountsMenuChoice != 0);
  }

  static void FundsTransfer()
  {
    FundsTransferPresentation.Transfer();
  }

  static void DisplayFundsTransferStatement()
  {
    DisplayFundsTransferStatementPresentation.Display();
  }

  static void DisplayAccountStatement()
  {
    DisplayAccountStatementPresentation.Display();

  }
}


