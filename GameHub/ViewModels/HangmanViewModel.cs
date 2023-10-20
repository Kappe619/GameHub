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
        int maxWrongGuesses = 11;   //only 11 Images, max index 10
        List<char> wrongCharsList = new();
        public string wrongChars = "";
        VerticalStackLayout verticalStack;
        HorizontalStackLayout guessedCharsStack;

        public HangmanViewModel(HangmanModel model, MainPage mainPage, VerticalStackLayout verticalStack, HorizontalStackLayout guessedCharsStack, Image failStateImg, int wordLenght = 5)
        {
            this.failStateImg = failStateImg;
            this.model = model;
            this.mp = mainPage;
            this.verticalStack = verticalStack;
            this.wordLenght = wordLenght;   //TODO: User should be able to choose
            guessedCharsArray = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', };
            StartGame();
        }


        string RandomWord()
        {
            model.NewRandomWord();
            word = model.Word.ToUpper();
            return word;
        }

        public void StartGame()
        {
            word = model.Word;
            //TODO: Update labels before first guess

            guessedCharsArray = new char[word.Length];
            guessesCount = 0;
            wrongGuessesCount = 0;
        }

        public HorizontalStackLayout CharsInBordersStack()
        {
            var stack = new HorizontalStackLayout();
            Border border;
            Label lbl = new Label();

            for (int i = 0; i < word.Length; i++)
            {
                lbl.Text = "testing";
                //string s = guessedCharsArray[i].ToString();
                //lbl.Text = s;
                border = new Border()
                {
                    Content = lbl,
                    Margin = new Thickness(20),
                };
                border.Content = lbl;
                stack.Children.Add(border);
            }
            return stack;
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
                    Margin = new Thickness(20),
                };
                st.Children.Add(lbl);
            }
            st.Background = Brush.LightGray;
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
            mp.DisplayAlert("Game over", $"You won, the war was {word}.", "ok");
            mp.ClearStack();

        }

        void GameLost()
        {
            //mp.DisplayAlert("Game over", $"Max wrong guesses reached, the word solution was {word}.", "ok");
            mp.DisplayAlert("Game over", $"Max wrong guesses reached, the word was {word}.", "ok");
            mp.ClearStack();

            //TODO: Add game lost logic
        }

        string SortedWrongGuesses()
        {
            wrongCharsList.Sort();
            string s = "Wrong: ";

            foreach (char c in wrongCharsList)
            {
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