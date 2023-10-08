using GameHub.Models;
using GameHub.ViewModels;

namespace GameHub.Views;

public partial class HangmanView : ContentView
{
	MainPage mainPage;
	HangmanModel model;
	HangmanViewModel vm;

	public HangmanView(MainPage mainPage)
	{
		this.mainPage = mainPage;
		model = new HangmanModel();
		vm = new HangmanViewModel(model, mainPage);
		InitializeComponent();

	}

	public string path1 = "Images/hangmanpicb.png";
    public string path2 = "Images/hangmanpicc.png";

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		image1.Source = new FileImageSource { File = path1 };
    }
}

