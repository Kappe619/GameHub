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

		public HangmanModel(Language language = Language.English, int wordLength = 5)
		{
			this.generator = new(language, wordLength);	//min length 3, max length 15			
			NewRandomWord();
			ImageList = CreateEasyImageList();
        }

		List<ImageSource> CreateEasyImageList()
		{
			List<ImageSource> list = new();

            list.Add(ImageSource.FromFile("Images/imgstart.png"));
            list.Add(ImageSource.FromFile("Images/imga.png"));
            list.Add(ImageSource.FromFile("Images/imgb.png"));
            list.Add(ImageSource.FromFile("Images/imgc.png"));
            list.Add(ImageSource.FromFile("Images/imgd.png"));
            list.Add(ImageSource.FromFile("Images/imge.png"));
            list.Add(ImageSource.FromFile("Images/imgf.png"));
            list.Add(ImageSource.FromFile("Images/imgg.png"));
            list.Add(ImageSource.FromFile("Images/imgh.png"));
            list.Add(ImageSource.FromFile("Images/imgi.png"));
            list.Add(ImageSource.FromFile("Images/imglost.png"));

			return list;
		}

		public ImageSource GetImageSource(int wrongGuesses)
		{
			return ImageList[wrongGuesses];
		}
    }
}

