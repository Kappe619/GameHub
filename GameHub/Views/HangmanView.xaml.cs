using GameHub.Models;
using GameHub.ViewModels;
namespace GameHub.Views;

public partial class HangmanView : ContentView
{
	MainPage mp;
	HangmanModel model;
	HangmanViewModel vm;
	Image pic;
	int wordLength;

	public HangmanView(MainPage mainPage, int wordLength = 4)
	{
		this.mp = mainPage;
		this.wordLength = wordLength;
        model = new HangmanModel();
        vm = new HangmanViewModel(model, mainPage, verticalStack, guessedCharsStack, failStateImg);
        InitializeComponent();		
    }


    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		string s = charInputEditor.Text;
		char c = char.Parse(s);

        vm.MakeGuess(c, guessedCharsStack);
		updateFailImg(vm.wrongGuessesCount);
    }

	void updateFailImg(int wrongGuesses)
	{
		failStateImg.Source = model.getSource(wrongGuesses);
	}
}

