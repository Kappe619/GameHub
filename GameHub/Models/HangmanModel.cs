using System;
namespace GameHub.Models
{
	public class HangmanModel
	{
        string word;

		public string Word
		{
			get => word;
			set => word = value;
		}

		//public string getPath(int wrongGuesses)
		//{
		//	return pathes[wrongGuesses];
		//}

		//public char getChar(int position)
		//{
		//	return word[position];	//TODO: add exception checks
		//}


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

		public HangmanModel()
		{
            //TODO: set pathes
            ImageSource state1 = ImageSource.FromFile("Images/hangmanpica.png");
            ImageSource state2 = ImageSource.FromFile("Images/hangmanpicb.png");
            ImageSource state3 = ImageSource.FromFile("Images/hangmanpicc.png");

        }
    }
}

