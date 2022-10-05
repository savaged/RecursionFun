namespace RecursionFun.LevenshteinDistance.Lib
{
    /// <summary>
    /// See https://programm.top/en/c-sharp/algorithm/levenshtein-distance/
    /// </summary>
    public class LevenshteinDistanceService : ILevenshteinDistanceService
    {
        public int Distance(string value1, string value2) =>
            Distance(value1, value1?.Length ?? 0, value2, value2?.Length ?? 0);

        private static int Distance(string value1, int len1, string value2, int len2)
        {
            if (string.IsNullOrEmpty(value1)) return len2;
            if (string.IsNullOrEmpty(value2)) return len1;

            if (len1 == 0) return len2;
            if (len2 == 0) return len1;

            var substitutionCost = 0;
            if (value1[len1 - 1] != value2[len2 - 1])
            {
                substitutionCost = 1;
            }
            var deletion = Distance(value1, len1 - 1, value2, len2) + 1;
            var insertion = Distance(value1, len1, value2, len2 - 1) + 1;
            var substitution = Distance(value1, len1 - 1, value2, len2 - 1) + substitutionCost;

            return Minimum(deletion, insertion, substitution);
        }

        private static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;

    }
}