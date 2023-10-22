using GameHub.Models;
using GameHub.ViewModels;
namespace GameHub.Views;

public partial class HangmanView : ContentView
{
    MainPage mp;
    HangmanModel model;
    HangmanViewModel vm;
    Image pic;

    //TODO: Max word length German is 15, English max is 11, add check or more/less words
    public HangmanView(MainPage mainPage, int wordLength = 4)
    {
        InitializeComponent();
        this.mp = mainPage;
        model = new HangmanModel(wordLength);
        vm = new HangmanViewModel(model, mainPage, verticalStack, baseGuessedCharsStack, failStateImg);
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        string s = charInputEditor.Text;
        char c = char.Parse(s);

        vm.MakeGuess(c, baseGuessedCharsStack);
        updateFailImg(vm.wrongGuessesCount);
    }

    void updateFailImg(int wrongGuesses)
    {
        failStateImg.Source = model.GetImageSource(wrongGuesses);
    }
}