using FizzBuzz.Game;

namespace FizzBuzz.Tests
{
    public class GameTests
    {
        //[Fact]
        //public void IsExists()
        //{
        //   GameBoard board = new GameBoard();
        //    int number = 4;

        //    string word = board.GetWord(number);
        //}

        [Fact]
        public void Given_Any_Number_Then_Return_Number_String()
        {
            //AAA
            //Arrange:
            GameBoard gameBoard = new GameBoard();
            int number = 4;

            //Act:
            string word = gameBoard.GetWord(number);

            //Assert:
            Assert.Equal(number.ToString(), word);
           
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void Given_Multiply_Three_Return_Fizz(int number)
        {
            GameBoard gameBoard = new GameBoard();

            string word = gameBoard.GetWord(number);
            Assert.Equal("Fizz", word);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void Given_Multiply_Three_Return_Buzz(int number)
        {
            GameBoard gameBoard = new GameBoard();

            string word = gameBoard.GetWord(number);
            Assert.Equal("Buzz", word);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void Given_Multiply_Three_And_Five_Return_FizzBuzz(int number)
        {
            GameBoard gameBoard = new GameBoard();

            string word = gameBoard.GetWord(number);
            Assert.Equal("FizzBuzz", word);
        }
    }
}
