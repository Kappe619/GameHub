using GameHub.Enums;
using Newtonsoft.Json;

namespace GameHub.Services
{
    public class WordGenerator
    {
        private List<string> words;
        private Random random;

        public WordGenerator(Language language = Language.German, int wordLength = 5)
        {
            words = new List<string>();
            random = new Random();
            LoadWordsFromFile(language, wordLength);
        }

        public string GetRandomWord()
        {
            if (words.Count == 0)
            {
                throw new InvalidOperationException("list is empty");
            }
            int index = random.Next(0, words.Count);
            return words[index];

        }

        void LoadWordsFromFile(Language language, int wordLength)
        {
            string path = GetResourcePath(language);
            string json;

            using (var stream = typeof(WordGenerator).Assembly.GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            var wordList = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);

            this.words = wordList[wordLength.ToString()];
        }

        private string GetResourcePath(Language language)
        {
            // Hier sollte der Pfad zu Ihrer JSON-Datei relativ zum Namespace sein
            //json files build action has to be "embedded resource"
            string path = $"GameHub.Resources.WordLists.{language}Words.json";
            return path;
        }
    }
}


