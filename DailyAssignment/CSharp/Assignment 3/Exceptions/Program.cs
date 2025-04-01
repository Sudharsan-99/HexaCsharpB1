namespace Exceptions
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                // Creating Bank Account
                BankAccount customerAccount = new BankAccount("John Doe", 5000);

                Console.Write("Enter amount to transfer: ");
                double transferAmount = double.Parse(Console.ReadLine());

                // Attempting fund transfer
                customerAccount.TransferFunds(transferAmount);
            }
            catch (ZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input! Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
