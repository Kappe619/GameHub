using GameHub.Models;
using GameHub.ViewModels;
using GameHub.Enums;
namespace GameHub.Views;

public partial class HangmanView : ContentView
{
    MainPage mp;
    HangmanModel model;
    HangmanViewModel vm;
    Image pic;

    //TODO: Max word length German is 15, English max is 11, add check or more/less words
    public HangmanView(MainPage mainPage, int wordLength = 4, GameHub.Enums.Language language = Language.English )
    {
        InitializeComponent();
        this.mp = mainPage;
        model = new HangmanModel(wordLength, language);
        vm = new HangmanViewModel(model, mainPage, verticalStack, baseGuessedCharsStack, failStateImg);
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        string s = charInputEditor.Text;
        char c = char.Parse(s);

        vm.MakeGuess(c, baseGuessedCharsStack);
        UpdateFailImg(vm.wrongGuessesCount);
    }

    void UpdateFailImg(int wrongGuesses)
    {
        failStateImg.Source = model.GetImageSource(wrongGuesses);
    }
}