using System;
using GameHub.Enums;
using GameHub.Services;
using GameHub.Views;

namespace GameHub
{
    public partial class MainPage : ContentPage
    {
        private HangmanView hangmanView;
        private TicTacToeView ticTacToeView;
        public double StepperValue { get; set; }
        private Language defaultLanguage;

        public MainPage()
        {
            InitializeComponent();
            StepperValue = 5;
            StepperLbl.Text = $"Level: {StepperValue}";
            BindingContext = this;
        }
        private void AddHangmanView()
        {
            ClearStack();

            var selected = LanguagePicker.SelectedItem.ToString();
            Language selectedLanguage;

            if (Enum.TryParse(selected, out selectedLanguage))
            {
                hangmanView = new HangmanView(this, (int)StepperValue, selectedLanguage);
                VerticalStack.Children.Add(hangmanView);
            }
            else
            { }
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

        void Stepper_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
        {
            if (sender is Stepper s)
            {
                this.StepperValue = s.Value;
            }
            StepperLbl.Text = $"Level: {StepperValue}";
        }

    }
}
