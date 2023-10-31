namespace HarshaBank.Exceptions;

/// <summary>
/// Exception class that represents error raised in Funds transaction class.
/// </summary>
public class FundsTransferException : ApplicationException
{
  public FundsTransferException(string message) : base(message) { }

  public FundsTransferException(string message, Exception innerException) : base(message, innerException) { }


}
