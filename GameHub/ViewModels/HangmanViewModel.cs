using System;
using GameHub.Models;

namespace GameHub.ViewModels
{
    public class HangmanViewModel
    {
        HangmanModel model;
        MainPage mp;
        Image failStateImg;
        string word;
        char[] guessedCharsArray;
        public int wrongGuessesCount = 0;
        string imagePath;
        int wordLenght;
        int maxWordLenght = 8;
        int guessesCount = 0;
        int charsSolved = 0;
        int maxWrongGuesses = 5;    //see switchCase in HangmanModel.cs
        List<char> wrongCharsList = new();
        public string wrongChars = "";
        VerticalStackLayout verticalStack;
        HorizontalStackLayout guessedCharsStack;

        public HangmanViewModel(HangmanModel model, MainPage mainPage, VerticalStackLayout verticalStack, HorizontalStackLayout guessedCharsStack, Image failStateImg, int wordLenght = 4)
        {
            this.failStateImg = failStateImg;
            this.model = model;
            this.mp = mainPage;
            this.verticalStack = verticalStack;
            this.wordLenght = wordLenght;   //User should be able to choose
            guessedCharsArray = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', };
            StartGame();
        }

        //public string ImagePath
        //{
        //    get => model.getPath(wrongGuessesCount);
        //    set => imagePath = value;
        //}

        string RandomWord()
        {
            return "ABC"; //TODO: add logic, has to be upper case
        }

        public void StartGame()
        {
            word = RandomWord();
            guessedCharsArray = new char[word.Length];
            guessesCount = 0;
            wrongGuessesCount = 0;
        }

        public HorizontalStackLayout UpdatedCharStack()
        {
            HorizontalStackLayout st = new();
            Label lbl;
            for (int i = 0; i < word.Length; i++)
            {
                lbl = new Label
                {
                    Text = guessedCharsArray[i].ToString(),
                    FontSize = 50,
                    Margin = new Thickness(5)
                };
                st.Children.Add(lbl);
            }
            st.Background = Brush.Pink;
            return st;
        }

        public void MakeGuess(char guessedChar, HorizontalStackLayout stack)
        {
            guessedChar = char.ToUpper(guessedChar);

            if (wrongCharsList.Contains(guessedChar) || guessedCharsArray.Contains(guessedChar))
            {
                mp.DisplayAlert("Alert", "Char already tried", "ok");
            }

            bool guessWasCorrect = false;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guessedChar)
                {
                    guessWasCorrect = true;
                    guessedCharsArray[i] = guessedChar;
                    charsSolved++;
                    if (charsSolved == word.Length)
                    {
                        GameWon();
                    }
                }
            }

            if (!guessWasCorrect)
            {
                if (!wrongCharsList.Contains(guessedChar))
                {
                    wrongCharsList.Add(guessedChar);
                    wrongGuessesCount++;

                    if (wrongGuessesCount == maxWrongGuesses)
                    {
                        GameLost();
                    }
                }
            }
            UpdateLabels(stack);
        }

        void GameWon()
        {
           //TODO: Add game won logic
           mp.DisplayAlert("Game over", "You won", "ok");
        }

        void GameLost()
        {
            mp.DisplayAlert("Game over", "Max wrong guesses reached", "ok");
            //TODO: Add game lost logic
        }

        string SortedWrongGuesses()
        {
            wrongCharsList.Sort();
            string s = "Wrong: ";

            foreach (char c in wrongCharsList) {
                s += c;                
            }
            return s;
        }

        void UpdateLabels(HorizontalStackLayout stack)
        {
            stack.Clear();
            stack.Children.Add(UpdatedCharStack());
            stack.Children.Add(new Label { Text = SortedWrongGuesses() });
        }
    }
}