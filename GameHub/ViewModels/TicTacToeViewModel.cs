using GameHub.Models;
using GameHub.Services;
using GameHub.Enums;

namespace GameHub.ViewModels
{
    public class TicTacToeViewModel
	{
        string current = "X";
        string[,] GameBoard = new String[3, 3];
        int clicked = 0;
        bool aiGame;
        TicTacToeModel model;
        MainPage mp;
        TicTacToeAI ai;

        public TicTacToeViewModel(TicTacToeModel model, MainPage mp, Difficulty diff, bool aiGame = false)
		{
            this.model = model;
            this.mp = mp;
            if (aiGame)
            {
                ai = new TicTacToeAI(diff);
            }
        }

        private bool DidCurrentPlayerWin()
        {
            if (GameBoard[0, 0] == current)
            {
                if ((GameBoard[0, 1] == current && GameBoard[0, 2] == current) ||   //1st row
                    (GameBoard[1, 0] == current && GameBoard[2, 0] == current) ||   //1st column
                    (GameBoard[1, 1] == current && GameBoard[2, 2] == current))    //diagonal top left
                {
                    return true;
                }
            }
            if (GameBoard[1, 0] == current && GameBoard[1, 1] == current && GameBoard[1, 2] == current) { return true; } //2nd row

            if (GameBoard[2, 0] == current && GameBoard[2, 1] == current && GameBoard[2, 2] == current) { return true; } //3rd row

            if (GameBoard[0, 1] == current && GameBoard[1, 1] == current && GameBoard[2, 1] == current) { return true; } //2nd column

            if (GameBoard[0, 2] == current && GameBoard[1, 2] == current && GameBoard[2, 2] == current) { return true; } //3rd column

            if (GameBoard[0, 2] == current && GameBoard[1, 1] == current && GameBoard[2, 0] == current) { return true; } //diagonal top right

            return false;
        }

        void UpdateGameBoard(string id)
        {
                int index1 = (int)id[0] - (int)'0'; //substract ASCI value from char to get index value
                int index2 = (int)id[1] - (int)'0';
                GameBoard[index1, index2] = current;           
        }


        void CloseGame()
        {
                mp.ClearStack();            
        }


        public void SquareClicked(Button btn) {

                if (btn.Text == " ")
                {
                    btn.Text = current;
                    UpdateGameBoard(btn.ClassId);
                    clicked++;
                }
            CheckWin();

                if (aiGame)
                {
                    MakeAiMove();
                }
                else
                {
                    current = model.ChangedString(current);
                }

            }


        public void MakeAiMove()  
        {
            //TODO: add pve logic
        }

        void CheckWin()
        {
            if (DidCurrentPlayerWin() || clicked == 9)
            {
                if (DidCurrentPlayerWin())
                {
                    var msg = $"Player {current} won";
                    mp.DisplayAlert("Game Over", msg, "OK");
                }
                else
                {
                    mp.DisplayAlert("Game over", "Draw", "Ok");
                }
                CloseGame();
            }
        }
    }
}

