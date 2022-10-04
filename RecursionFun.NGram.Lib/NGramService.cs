using System.Linq;
using System.Collections.Generic;

namespace savaged.NGram.Lib
{
    public interface INGramService
    {
        IList<string> ToNGrams(string phrase);
    }

    public class NGramService : INGramService
    {
        public IList<string> ToNGrams(string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return new List<string>();

            var nGrams = new List<string> { phrase };
            LoadNGrams(phrase, nGrams);
            return nGrams;
        }

        private void LoadNGrams(string phrase, IList<string> nGrams)
        {
            if (string.IsNullOrEmpty(phrase) || nGrams == null) return;
            
            var words = phrase.Split(' ');
            if (words.Length == 1)
            {
                nGrams.Add(words[0]);
                return;
            }
            var reduced = words.Reverse().Skip(1).Reverse().Aggregate((c, n) => $"{c} {n}");
            nGrams.Add(reduced);
            LoadNGrams(reduced, nGrams);
        }
        
    }
}