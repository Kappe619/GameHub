using GameHub.Enums;
using Newtonsoft.Json;

namespace GameHub.Services
{
    public class WordGenerator
    {
        private List<string> words;
        private Random random;

        public WordGenerator(Language language)
        {
            words = new List<string>();
            random = new Random();
            LoadWordsFromFile(language);
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

        void LoadWordsFromFile(Language language)
        {
            string path = GetResourcePath(language);
            string json;

            using (var stream = typeof(WordGenerator).Assembly.GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            var wordList = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);

            List<string> wordsWithThreeLetters = wordList["3"];
            words = wordsWithThreeLetters;
            int i = 8;
        }

        private string GetResourcePath(Language language)
        {
            // Hier sollte der Pfad zu Ihrer JSON-Datei relativ zum Namespace sein
            string path = $"GameHub.Resources.WordLists.{language}Words.json";
            return path;
        }
    }
}


