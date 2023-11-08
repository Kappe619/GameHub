using GameHub.Enums;
using GameHub.Services;
namespace GameHub.Models
{
    public class HangmanModel
	{
        string word;
		WordGenerator generator;
		List<ImageSource> ImageList;
 
		public string Word
		{
			get => word;
			set => word = value;
		}

		public void NewRandomWord()
		{
			Word = generator.GetRandomWord();
		}

		public HangmanModel(int wordLength, Language language = Language.English)
		{
			this.generator = new(language, wordLength);	//min length 3, max length 15			
			NewRandomWord();
			ImageList = CreateEasyImageList();
        }

		List<ImageSource> CreateEasyImageList()
		{
            List<ImageSource> list = new()
            {
                ImageSource.FromFile("Images/imgstart.png"),
                ImageSource.FromFile("Images/imga.png"),
                ImageSource.FromFile("Images/imgb.png"),
                ImageSource.FromFile("Images/imgc.png"),
                ImageSource.FromFile("Images/imgd.png"),
                ImageSource.FromFile("Images/imge.png"),
                ImageSource.FromFile("Images/imgf.png"),
                ImageSource.FromFile("Images/imgg.png"),
                ImageSource.FromFile("Images/imglost.png")
            };

            return list;
		}

		public ImageSource GetImageSource(int wrongGuesses)
		{
			return ImageList[wrongGuesses];
		}
    }
}

