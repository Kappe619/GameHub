namespace GameHub.Views;

public partial class HangmanView : ContentView
{
	public HangmanView()
	{
		InitializeComponent();

	}

	public string path1 = "Images/hangmanpicb.png";
    public string path2 = "Images/hangmanpicc.png";

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		image1.Source = new FileImageSource { File = path1 };
    }
}

