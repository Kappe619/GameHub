using System;
using GameHub.Views;

namespace GameHub
{
    public partial class MainPage : ContentPage
    {
        private HangmanView hangmanView;
        private TicTacToeView ticTacToeView;

        public MainPage()
        {
            InitializeComponent();
        }

        private void AddHangmanView()
        {
            ClearStack();
            hangmanView = new HangmanView();
            VerticalStack.Children.Add(hangmanView);
        }

        private void AddTicTacToeView()
        {
            ClearStack();
            ticTacToeView = new TicTacToeView(this);
            VerticalStack.Children.Add(ticTacToeView);
        }

        void HangmanBtnClicked(System.Object sender, System.EventArgs e)
        {
            AddHangmanView();
        }

        void TicTacToeBtnClicked(System.Object sender, System.EventArgs e)
        {
            AddTicTacToeView();
        }

        public void ClearStack()
        {
            VerticalStack.Clear();
        }
    }
}
