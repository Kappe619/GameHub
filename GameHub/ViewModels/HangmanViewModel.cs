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
        int maxWordLenght = 8;
        int guessesCount = 0;
        int charsSolved = 0;
        int maxWrongGuesses = 11;   //only 11 Images, max index 10
        List<char> wrongCharsList = new();
        public string wrongChars = "";
        VerticalStackLayout verticalStack;
        HorizontalStackLayout guessedCharsStack;
        int defaultFontSize = 20;

        public HangmanViewModel(HangmanModel model, MainPage mainPage, VerticalStackLayout verticalStack, HorizontalStackLayout guessedCharsStack, Image failStateImg, int wordLenght = 5)
        {
            this.failStateImg = failStateImg;
            this.model = model;
            this.mp = mainPage;
            this.verticalStack = verticalStack;
            StartGame();
            UpdateLabels(guessedCharsStack);
        }

        public void StartGame()
        {
            word = model.Word;
            guessedCharsArray = new char[word.Length];
            guessesCount = 0;
            wrongGuessesCount = 0;
        }

        public HorizontalStackLayout CharsInBordersStack()
        {
            var stack = new HorizontalStackLayout();
            Border border;

            for (int i = 0; i < word.Length; i++)
            {
                string s = guessedCharsArray[i].ToString();
                Label lbl = new()
                {
                    FontSize = defaultFontSize,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                };



                lbl.Text = s;
                border = new Border()
                {
                    Content = lbl,
                    HeightRequest = 50,
                    WidthRequest = 50,
                    Margin = new Thickness(2),

                };
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
                    FontSize = defaultFontSize,
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
            mp.DisplayAlert("Game over", $"You won, the word was {word}.", "ok");
            mp.ClearStack();
        }

        void GameLost()
        {
            mp.DisplayAlert("Game over", $"Max wrong guesses reached, the word was {word}.", "ok");
            mp.ClearStack();
        }

        string SortedWrongGuesses()
        {
            wrongCharsList.Sort();
            string s = "Wrong chars: ";

            for (int i = 0; i < wrongCharsList.Count; i++)
            {
                s += wrongCharsList[i];
                if (i < wrongCharsList.Count - 1)
                {
                    s += ", ";
                }
            }
            return s;
        }

        void UpdateLabels(HorizontalStackLayout stack)
        {
            stack.Clear();
            stack.Children.Add(CharsInBordersStack());
            stack.Children.Add(new Label
            {
                Text = SortedWrongGuesses(),
                Margin = 10,
                FontSize = defaultFontSize,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            });
        }
    }
}