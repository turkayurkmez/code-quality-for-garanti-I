namespace FizzBuzz.Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            for (int i = 0; i < 100; i++) {
                string word = gameBoard.GetWord(i);
                Console.WriteLine(word);
            }
        }
    }
}
