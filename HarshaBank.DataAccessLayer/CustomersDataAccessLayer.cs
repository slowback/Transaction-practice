using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.DataAccessLayer.DALContracts;

namespace HarshaBank.DataAccessLayer;


public class CustomerDataAccessLayer : ICustomersDataAccessLayer
{
  #region Fields
  private static List<Customer>? _customers;
  #endregion

  #region Constructors
  static CustomerDataAccessLayer()
  {
    _customers = new List<Customer>();

  }
  #endregion

  #region Properties
  /// <summary>
  /// Represents source customers collection
  /// </summary>
  private static List<Customer> Customers
  {
    get => _customers ?? new List<Customer>();
    set
    {
      _customers = value;
    }
  }
  #endregion

  #region Methods
  /// <summary>
  /// Returns all existing customers
  /// </summary>
  /// <returns>Custoemrs list</returns>
  public List<Customer> GetCustomers()
  {
    try
    {
      // Create a new customers list
      List<Customer> customersList = new();

      // copy all customers from the source collection into the newCustomers list
      Customers.ForEach(item => customersList.Add(item.Clone() as Customer ?? new Customer()));
      return customersList;
    }
    catch (CustomerException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }

  }

  /// <summary>
  /// Returns list of customers that are matching with specified criteria
  /// </summary>
  /// <param name="predicate">Lambda expression with condition</param>
  /// <returns>List of matching customers</returns>
  public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
  {
    try
    {
      // Create a new customers list
      List<Customer> customersList = new();

      // Filter the collection
      List<Customer> filterCustomers = Customers.FindAll(predicate);

      // copy all customers from the source collection into the newCustomers list
      filterCustomers.ForEach(item => customersList.Add(item.Clone() as Customer ?? new Customer()));

      return filterCustomers;

    }
    catch (CustomerException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  /// <summary>
  /// Adds a new customer to the existing list
  /// </summary>
  /// <param name="customer">Customer object to add</param>
  /// <returns>Guid of newly created customer</returns>
  public Guid AddCustomer(Customer customer)
  {
    try
    {
      // generate new Guid
      customer.CustomerID = Guid.NewGuid();

      // Add customer
      Customers.Add(customer);
      return customer.CustomerID;
    }
    catch (CustomerException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  /// <summary>
  /// Updates an existing customer's details
  /// </summary>
  /// <param name="customer">Customer object with update details</param>
  /// <returns>Determines whether the customer is updated or not</returns>
  public bool UpdateCustomer(Customer customer)
  {
    try
    {
      // Find existing customer by CustomerID
      Customer? existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

      // Update all details of customer
      if (existingCustomer != null)
      {
        existingCustomer.CustomerCode = customer.CustomerCode;
        existingCustomer.CustomerName = customer.CustomerName;
        existingCustomer.Address = customer.Address;
        existingCustomer.Landmark = customer.Landmark;
        existingCustomer.City = customer.City;
        existingCustomer.Country = customer.Country;
        existingCustomer.Mobile = customer.Mobile;

        return true;  // indicates that customers is updated
      }
      return false;

    }
    catch (CustomerException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  /// <summary>
  /// Deleted an existing customer based on CustomerID
  /// </summary>
  /// <param name="customerID">CustomerID to delete</param>
  /// <returns></returns>
  public bool DeleteCustomer(Guid customerID)
  {
    try
    {
      // Delete customer by CustomerID
      if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
        return true;
      else
        return false;
    }
    catch (CustomerException)
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
