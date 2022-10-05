using RecursionFun.LevenshteinDistance.Lib;

namespace RecursionFun.Test;

public class LevenshteinDistanceServiceTests
{
    private readonly ILevenshteinDistanceService _levenshteinDistanceService;
    
    public LevenshteinDistanceServiceTests()
    {
        _levenshteinDistanceService = new LevenshteinDistanceService();
    }
    
    [Fact]
    public void TestLevenshteinDistanceService()
    {
        var result = _levenshteinDistanceService.Distance("Monday", "Saturday");
        Assert.Equal(5, result);
        // deletion
        result = _levenshteinDistanceService.Distance("Monday", "onday");
        Assert.Equal(1, result);
        // substitution
        result = _levenshteinDistanceService.Distance("Monday", "Mondey");
        Assert.Equal(1, result);
        // addition
        result = _levenshteinDistanceService.Distance("Monday", "Mondayy");
        Assert.Equal(1, result);
        // transposition
        result = _levenshteinDistanceService.Distance("Monday", "Mondya");
        Assert.Equal(2, result);
        // case
        result = _levenshteinDistanceService.Distance("Monday", "monday");
        Assert.Equal(1, result);
        // empties
        result = _levenshteinDistanceService.Distance("Monday", string.Empty);
        Assert.Equal(6, result);
        result = _levenshteinDistanceService.Distance(string.Empty, "Monday");
        Assert.Equal(6, result);
        // fun
        result = _levenshteinDistanceService.Distance("😄😄😄", "😄😓😄");
        Assert.Equal(1, result);
    }
}