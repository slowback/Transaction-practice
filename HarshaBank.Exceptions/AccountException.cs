namespace HarshaBank.Exceptions;

/// <summary>
/// Exception class that represent error raised in Account classification.
/// </summary>
public class AccountException : ApplicationException
{

  /// <summary>
  /// Constructor that initializes exception message
  /// </summary>
  /// <param name="message"></param>
  public AccountException(string message) : base(message) { }

  /// <summary>
  /// Constructor that initializes exception message and inner exception
  /// </summary>
  /// <param name="message"></param>
  /// <param name="inner"></param>
  public AccountException(string message, Exception inner) : base(message, inner) { }

}
