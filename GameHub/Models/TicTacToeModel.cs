using System;
namespace GameHub.Models
{
	public class TicTacToeModel
	{   

        public TicTacToeModel()
		{
		}

        public String ChangedString(String s)
        {
            if (s == "X") return "O";
            else return "X";
        }

    }
}

