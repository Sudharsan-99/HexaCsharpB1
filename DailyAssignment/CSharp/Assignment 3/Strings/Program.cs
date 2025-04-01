namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Q1..
            Console.Write("Enter a word: ");
            string? word1 = Console.ReadLine();
            Console.WriteLine("Length of the word: " + word1.Length);

            //Q2..
            Console.Write("Enter a word: ");
            string word2 = Console.ReadLine();
            char[] charArray = word2.ToCharArray();
            Array.Reverse(charArray);
            string reversedWord = new string(charArray);
            Console.WriteLine("Reversed word: " + reversedWord);


            //Q3..
            Console.Write("Enter first word: ");
            string word3 = Console.ReadLine();

            Console.Write("Enter second word: ");
            string word4 = Console.ReadLine();

            if (word3.Equals(word4))
            {
                Console.WriteLine("The words are the same.");
            }
            else
            {
                Console.WriteLine("The words are different.");
            }
        }
    }
}
