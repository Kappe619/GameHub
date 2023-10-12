using GameHub.Models;
using GameHub.ViewModels;
namespace GameHub.Views;

public partial class HangmanView : ContentView
{
	MainPage mainPage;
	HangmanModel model;
	HangmanViewModel vm;
	int wordLength;

	public HangmanView(MainPage mainPage, int wordLength = 4)
	{
		this.mainPage = mainPage;
		this.wordLength = wordLength;
        model = new HangmanModel();
        vm = new HangmanViewModel(model, mainPage, verticalStack, guessedCharsStack);
        InitializeComponent();
        //image1.Source = new FileImageSource { File = path1 };

    }

    public string path1 = "Images/hangmanpicb.png";
    public string path2 = "Images/hangmanpicc.png";


    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		string s = charInputEditor.Text;
		char c = char.Parse(s);
        vm.MakeGuess(c, guessedCharsStack);
	}

}

