namespace GameHub.Views;

public partial class TicTacToeView : ContentView
{
    Page mainPage; 
    public TicTacToeView(Page mainPage)
    {
        this.mainPage = mainPage;
        InitializeComponent();
    }

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
                current = ChangedString(current);
                UpdateGameBoard(btn.ClassId);
                clicked++;
            }
            if (clicked == 9)
            {
                await mainPage.DisplayAlert("Game over", "Draw", "Ok");
                CloseGame();
            }
            if (IsGameOver(btn.ClassId))
            {
                await App.Current.MainPage.DisplayAlert("Game Over", "You won", "OK");
                CloseGame();
            }
        }
    }

    private bool IsGameOver(String id)
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
    {
        if (mainPage is MainPage mp)
        {
            mp.ClearStack();
        }
    }
}
