
namespace HarshaBank.Configuration;

/// <summary>
/// Project level configuration settings
/// </summary>
public class Settings
{
  /// <summary>
  /// Customer number starts for 1001; incremented by 1
  /// </summary>
  public static long BaseCustomerNo { get; set; } = 1000;
  public static long BaseAccountNo { get; set; } = 10000;

}
