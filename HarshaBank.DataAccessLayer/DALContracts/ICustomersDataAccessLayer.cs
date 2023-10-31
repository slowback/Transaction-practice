using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer.DALContracts;

/// <summary>
/// Interface that represents customers data access layer
/// </summary>
public interface ICustomersDataAccessLayer
{
  /// <summary>
  /// Return all existing customers
  /// </summary>
  /// <returns></returns>
  public List<Customer> GetCustomers();

  /// <summary>
  /// REturns a set of customers that matches with specified criteria
  /// </summary>
  /// <param name="predicate">Lambda expression that contains condition to check</param>
  /// <returns>The list of matching customers</returns>
  public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);

  /// <summary>
  /// Adds a new cutomer to existing customers list
  /// </summary>
  /// <param name="customer">The customer object to add</param>
  /// <returns>Returns GUID, that indicate the customer is added successfully</returns>
  public Guid AddCustomer(Customer customer);

  /// <summary>
  /// Update an existing customer
  /// </summary>
  /// <param name="customer">Customer object that contains customer details to update</param>
  /// <returns>Return ture, that indicates the customer is updated successfully</returns>
  public bool UpdateCustomer(Customer customer);

  /// <summary>
  /// Deleted an existing customer
  /// </summary>
  /// <param name="customerID">CustomerID to delete</param>
  /// <returns>Return true, that indicates the customer is deleted successfully</returns>
  public bool DeleteCustomer(Guid customerID);

}
