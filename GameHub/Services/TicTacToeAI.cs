using GameHub.Enums;
namespace GameHub.Services
{
	public class TicTacToeAI
	{

		Difficulty diff;
		Random ran = new Random();
		string[,] GameBoard;
		string ai = "a";
		string player = "p";


		public TicTacToeAI(Difficulty difficulty)
		{
			this.diff = difficulty;
		}

		public (int row, int column) GetNextMove(int playerRow, int playerColumn)
		{

			GameBoard[playerRow, playerColumn] = player;

			//TODO: Add ai move logic
			int row = 0;
			int column = 0;			

			return (row, column);
		}
	}
}

