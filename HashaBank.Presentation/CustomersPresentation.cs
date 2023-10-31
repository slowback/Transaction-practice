using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;


namespace HashaBank.Presentation;

public static class CustomersPresentation
{
  internal static void AddCustomer()
  {
    try
    {
      // Create an object Customer
      Customer customer = new();

      //read all details from the user
      Console.WriteLine("\n******* ADD CUSTOMER *******");
      Console.Write("Customer Name: ");
      customer.CustomerName = Console.ReadLine();
      Console.Write("Address: ");
      customer.Address = Console.ReadLine();
      Console.Write("Landmark: ");
      customer.Landmark = Console.ReadLine();
      Console.Write("City: ");
      customer.City = Console.ReadLine();
      Console.Write("Country: ");
      customer.Country = Console.ReadLine();
      Console.Write("Mobile: ");
      customer.Mobile = Console.ReadLine();
      Console.WriteLine();

      // Create BL object
      ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
      Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);
      Console.WriteLine(newGuid);
      List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newGuid);
      if (matchingCustomers.Count >= 1)
      {
        Console.WriteLine("New Customer Code: " + matchingCustomers[0].CustomerCode);
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
  internal static void ViewCustomers()
  {
    try
    {
      // Create BL object
      ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
      List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();

      // read all customers
      Console.WriteLine("\n******** ALL CUSTOMERS ********");
      PrintAllCustomer(allCustomers);
    }
    catch (CustomerException)
    {
      throw;
    }
  }

  internal static void Search()
  {
    Console.WriteLine("\n******* SEARCH *******");
    Console.Write("Enter name: ");
    Customer? foundCustomer = null;
    string? searchName = Console.ReadLine();
    string[]? splitName = searchName?.Split();

    ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
    List<Customer> allCustomer = customersBusinessLogicLayer.GetCustomers();
    foreach (var cus in allCustomer)
    {
      string[]? cusName = cus.CustomerName?.Split();
      if (splitName?.Length == 2)   // compare firstname and lastname
      {
        if (((cusName?[0].ToLower() == splitName?[0].ToLower()) &&
          (cusName?[1].ToLower() == splitName?[1].ToLower())) ||
          (cusName?[0].ToLower() == splitName?[0].ToLower()))
        {
          foundCustomer = cus;
          break;
        }
      }
      else if (splitName?.Length == 1)
      {
        if (cusName?[0].ToLower() == splitName?[0].ToLower())    // compare firstname only.
        {
          foundCustomer = cus;
          break;
        }
      }
    }

    if (foundCustomer is not null)
    {
      List<Customer> customers = new() { foundCustomer };
      Console.WriteLine("\n******** CUSTOMER ********");
      PrintAllCustomer(customers);
    }
    else
    {
      Console.WriteLine("Not found customer name: " + searchName);
    }
  }
  internal static void UpdateCustomer()
  {
    Customer? selectedEditCustomer;
    long editCode;
    string? editName, editAddress, editLandmark, editCity, editCountry, editMobile;


    Console.WriteLine("\n******** EDIT CUSTOMERS *******\n");
    ViewCustomers();
    Console.Write("Enter the Customer Code that you want to edit: ");
    editCode = long.Parse(Console.ReadLine() ?? "");

    ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
    List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
    selectedEditCustomer = allCustomers.Find(customer => customer.CustomerCode == editCode);

    if (selectedEditCustomer is null)
      Console.WriteLine("Wrong customer code");
    else
    {
      try
      {

        Console.Write($"Enter new Name({selectedEditCustomer.CustomerName}): ");
        editName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(editName))
          editName = selectedEditCustomer.CustomerName;

        Console.Write($"Enter new Address({selectedEditCustomer.Address}): ");
        editAddress = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(editAddress))
          editAddress = selectedEditCustomer.Address;

        Console.Write($"Enter new Landmark({selectedEditCustomer.Landmark}): ");
        editLandmark = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(editLandmark))
          editLandmark = selectedEditCustomer.Landmark;

        Console.Write($"Enter new City({selectedEditCustomer.City}): ");
        editCity = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(editCity))
          editCity = selectedEditCustomer.City;

        Console.Write($"Enter new Country({selectedEditCustomer.Country}): ");
        editCountry = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(editCountry))
          editCountry = selectedEditCustomer.Country;

        Console.Write($"Enter new Mobile({selectedEditCustomer.Mobile}): ");
        editMobile = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(editMobile))
          editMobile = selectedEditCustomer.Mobile;

        Customer newCustomer = new()
        {
          CustomerID = selectedEditCustomer.CustomerID,
          CustomerCode = selectedEditCustomer.CustomerCode,
          CustomerName = editName,
          Address = editAddress,
          Landmark = editLandmark,
          City = editCity,
          Country = editCountry,
          Mobile = editMobile
        };

        bool updated = customersBusinessLogicLayer.UpdateCustomer(newCustomer);
        if (updated)
        {
          Console.WriteLine(" NEW CUSTOMER DETAILS");
          PrintAllCustomer(newCustomer);

          Console.WriteLine("Customer Updated.");
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
  }
  internal static void DeleteCustomer()
  {
    Console.WriteLine("\n******* Delete *******");
    Console.Write("Enter name: ");
    string? searchName = Console.ReadLine()?.Trim();

    ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();
    List<Customer> allCustomer = customersBusinessLogicLayer.GetCustomers();
    Customer? customerNameSelected = null;

    foreach (var cus in allCustomer)
    {
      string[]? cusName = cus.CustomerName?.Split();
      if (cusName?[0].ToLower() == searchName?.ToLower())
      {
        customerNameSelected = cus;
        break;
      }
    }

    if (customerNameSelected is not null)
    {
      Console.WriteLine("\n******** CUSTOMER ********");
      PrintAllCustomer(customerNameSelected);

      string? confirmDelete;

      Console.Write("Confirm Delete(yes or no): ");
      confirmDelete = Console.ReadLine();
      if (confirmDelete?.ToLower() == "yes")
      {
        //----- For test ----
        // bool deleted = customersBusinessLogicLayer.DeleteCustomer(Guid.NewGuid());

        bool deleted = customersBusinessLogicLayer.DeleteCustomer(customerNameSelected.CustomerID);

        if (deleted)
        {
          Console.WriteLine("\nCustomer deleted successfully");
        }
        else
        {
          Console.WriteLine("\nCustomer not deleted successfully");
        }
      }
    }
    else
    {
      Console.WriteLine("Not found customer name: " + searchName);
    }
  }

  public static void PrintAllCustomer(List<Customer> customers)
  {
    foreach (var item in customers)
    {
      Console.WriteLine("Customer Code: " + item.CustomerCode);
      Console.WriteLine("Customer Name: " + item.CustomerName);
      Console.WriteLine("Customer Address: " + item.Address);
      Console.WriteLine("Customer Landmark: " + item.Landmark);
      Console.WriteLine("Customer City: " + item.City);
      Console.WriteLine("Customer Country: " + item.Country);
      Console.WriteLine("Customer Mobile: " + item.Mobile);
      Console.WriteLine();
    }
  }

  public static void PrintAllCustomer(Customer customer)
  {
    Console.WriteLine("Customer Code: " + customer.CustomerCode);
    Console.WriteLine("Customer Name: " + customer.CustomerName);
    Console.WriteLine("Customer Address: " + customer.Address);
    Console.WriteLine("Customer Landmark: " + customer.Landmark);
    Console.WriteLine("Customer City: " + customer.City);
    Console.WriteLine("Customer Country: " + customer.Country);
    Console.WriteLine("Customer Mobile: " + customer.Mobile);
    Console.WriteLine();
  }
}
