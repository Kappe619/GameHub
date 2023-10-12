using System;
namespace GameHub.Models
{
	public class HangmanModel
	{
        string path1 = "Images/hangmanpica.png";
        string path2 = "Images/hangmanpicb.png";

        string[] pathes = new string[] { "path1", "path2" };

        string word;

		public string Word
		{
			get => word;
			set => word = value;
		}

		public string getPath(int wrongGuesses)
		{
			return pathes[wrongGuesses];
		}

		public char getChar(int position)
		{
			return word[position];	//TODO: add exception checks
		}




		public HangmanModel()
		{
			//TODO: set pathes
		}
	}
}

