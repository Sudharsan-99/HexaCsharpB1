namespace Exceptions
{
    internal class Program
    {
        static void Main()
        {
            BankAccount customerAccount = new BankAccount("Sudharsan", 5000);
            Console.Write("Enter amount to transfer: ");
            double  transferAmount = double.Parse(Console.ReadLine());
            try
            {
                customerAccount.TransferFunds(transferAmount);
            }
            catch (ZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
