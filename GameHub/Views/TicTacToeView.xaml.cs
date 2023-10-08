using GameHub.Models;
using GameHub.ViewModels;

namespace GameHub.Views;

public partial class TicTacToeView : ContentView
{
    MainPage mainPage;
    TicTacToeViewModel vm;
    TicTacToeModel model;

    public TicTacToeView(MainPage mainPage)
    {
        this.mainPage = mainPage;
        model = new TicTacToeModel();
        vm = new TicTacToeViewModel(model, mainPage);
        InitializeComponent();
    }

    void SquareClicked(System.Object sender, System.EventArgs e)
    {
        vm.SquareClicked(sender as Button);
    }
}