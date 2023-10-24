using GameHub.Models;
using GameHub.ViewModels;

namespace GameHub.Views;

public partial class TicTacToeView : ContentView
{
<<<<<<< HEAD
    MainPage mainPage;
    TicTacToeViewModel vm;
    TicTacToeModel model;

    public TicTacToeView(MainPage mainPage)
=======
    Page mainPage;
    public TicTacToeView(Page mainPage)
>>>>>>> main
    {
        this.mainPage = mainPage;
        model = new TicTacToeModel();
        vm = new TicTacToeViewModel(model, mainPage);
        InitializeComponent();
    }

<<<<<<< HEAD
    void SquareClicked(System.Object sender, System.EventArgs e)
=======
    string current = "X";
    string[,] GameBoard = new String[3, 3];
    int clicked = 0;

    async void SquareClicked(System.Object sender, System.EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Text == " ")
            {
                btn.Text = current;
                UpdateGameBoard(btn.ClassId);
                clicked++;
            }
            if (DidCurrentPlayerWin() || clicked == 9)
            {
                if (DidCurrentPlayerWin())
                {                    
                    var msg = $"Player {current} won";
                    await App.Current.MainPage.DisplayAlert("Game Over", msg, "OK");
                }
                else
                {
                    await mainPage.DisplayAlert("Game over", "Draw", "Ok");
                }
                CloseGame();
            }
            current = ChangedString(current);
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

    String ChangedString(String s)
    {
        if (s == "X") return "O";
        else return "X";
    }

    void UpdateGameBoard(string id)
    {
        int index1 = (int)id[0] - (int)'0'; //substract ASCI value from char to get index value
        int index2 = (int)id[1] - (int)'0';
        GameBoard[index1, index2] = current;
    }

    void CloseGame()
>>>>>>> main
    {
        vm.SquareClicked(sender as Button);
    }
}