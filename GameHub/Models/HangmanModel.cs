using GameHub.Enums;
using GameHub.Services;
namespace GameHub.Models
{
    public class HangmanModel
	{
        string word;
		WordGenerator generator;

		public string Word
		{
			get => word;
			set => word = value;
		}

		public void NewRandomWord()
		{
			Word = generator.GetRandomWord();
		}

		public ImageSource getSource(int wrongGuesses)	//TODO: add all correct images
		{
			switch (wrongGuesses)
			{
				case 1:
					return ImageSource.FromFile("Images/hangmanpica.png");
				case 2:
                    return ImageSource.FromFile("Images/hangmanpicb.png");
				case 3:
					return ImageSource.FromFile("Images/hangmanpicc.png");
				case 4:
                    return ImageSource.FromFile("Images/hangmanpica.png");
				case 5:
                    return ImageSource.FromFile("Images/hangmanpicb.png");	

                default:	//maxWrongGuesses in vm
                    return ImageSource.FromFile("Images/hangmanpicc.png");                    
            }
		}

		public HangmanModel(Language language = Language.German)
		{
			this.generator = new(language);
			NewRandomWord();
            //TODO: set pathes
            ImageSource state1 = ImageSource.FromFile("Images/hangmanpica.png");
            ImageSource state2 = ImageSource.FromFile("Images/hangmanpicb.png");
            ImageSource state3 = ImageSource.FromFile("Images/hangmanpicc.png");

        }
    }
}

