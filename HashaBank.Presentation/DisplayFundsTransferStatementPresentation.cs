using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
namespace HashaBank.Presentation;


public static class DisplayFundsTransferStatementPresentation
{
  internal static void Display()
  {
    IFundsTransferBusinessLogicLayer fundsTransferBusinessLogicLayer = new FundsTransferBusinessLogicLayer();
    List<FundsTransfer> fundsTransfers = fundsTransferBusinessLogicLayer.GetTransactions();
    Console.WriteLine("\n******* STATEMENT TRANSFERS ****");
    FundsTransferPresentation.PrintAllTransfer(fundsTransfers);
  }
}
