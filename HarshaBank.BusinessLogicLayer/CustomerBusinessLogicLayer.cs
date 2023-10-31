using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.DataAccessLayer;

namespace HarshaBank.BusinessLogicLayer;

/// <summary>
/// Represents customer business logic
/// </summary>
public class CustomerBusinessLogicLayer : ICustomersBusinessLogicLayer
{
  #region Private Field
  private ICustomersDataAccessLayer _customersDataAccessLayer;
  #endregion

  #region Constructors
  /// <summary>
  /// Construtor that initializes CustomersDataAccessLayer
  /// </summary>
  public CustomerBusinessLogicLayer()
  {
    _customersDataAccessLayer = new CustomerDataAccessLayer();
  }
  #endregion

  #region Properties
  /// <summary>
  /// Private property that represents reference of CustomersDataAccessLayer
  /// </summary>
  private ICustomersDataAccessLayer CustomersDataAccessLayer
  {
    get => _customersDataAccessLayer;
    set => _customersDataAccessLayer = value;
  }
  #endregion

  #region Methods
  /// <summary>
  /// Return all existing customers
  /// </summary>
  /// <returns>List of customers</returns>
  public List<Customer> GetCustomers()
  {
    try
    {
      // invoke DAL
      return CustomersDataAccessLayer.GetCustomers();
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
  /// REturns a set of customers that matches with specified criteria
  /// </summary>
  /// <param name="predicate">Lambda expression that contains condition to check</param>
  /// <returns>The list of matching customers</returns>
  public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
  {
    try
    {
      // invoke DAL
      return CustomersDataAccessLayer.GetCustomersByCondition(predicate);
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
  /// Adds a new cutomer to existing customers list
  /// </summary>
  /// <param name="customer">The customer object to add</param>
  /// <returns>Returns GUID, that indicate the customer is added successfully</returns>
  public Guid AddCustomer(Customer customer)
  {
    try
    {
      // get all customers
      List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
      long maxCustCode = 0;
      foreach (var item in allCustomers)
      {
        if (item.CustomerCode > maxCustCode)
          maxCustCode = item.CustomerCode;
      }

      if (allCustomers.Count >= 1)
      {
        customer.CustomerCode = maxCustCode + 1;
      }
      else
      {
        customer.CustomerCode = HarshaBank.Configuration.Settings.BaseCustomerNo + 1;
      }

      return CustomersDataAccessLayer.AddCustomer(customer);
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
  /// Update an existing customer
  /// </summary>
  /// <param name="customer">Customer object that contains customer details to update</param>
  /// <returns>Return ture, that indicates the customer is updated successfully</returns>
  public bool UpdateCustomer(Customer customer)
  {
    try
    {
      return CustomersDataAccessLayer.UpdateCustomer(customer);
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
  /// Deleted an existing customer
  /// </summary>
  /// <param name="customerID">CustomerID to delete</param>
  /// <returns>Return true, that indicates the customer is deleted successfully</returns>
  public bool DeleteCustomer(Guid customerID)
  {
    try
    {
      return CustomersDataAccessLayer.DeleteCustomer(customerID);
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
