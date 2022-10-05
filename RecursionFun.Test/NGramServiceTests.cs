using RecursionFun.NGram.Lib;

namespace RecursionFun.Test;

public class NGramServiceTests
{
    private readonly INGramService _nGramService;

    public NGramServiceTests()
    {
        _nGramService = new NGramService();
    }
            
    [Fact]
    public void NGramTest()
    {
        //Given phrase is: "Come as you are"
        var phrase = "Come as you are";
        //When split is run 
        var result = _nGramService.ToNGrams(phrase);
        //Then Result is a collection
        Assert.NotNull(result);
        //And 1st item in the collection is "Come as you are"
        Assert.Equal("Come as you are", result[0]);
        //And 2nd item in the collection is "Come as you" 
        Assert.Equal("Come as you", result[1]);
        //And 3rd item in the collection is "Come as"
        Assert.Equal("Come as", result[2]);
        //And 4th item in the collection is "Come"
        Assert.Equal("Come", result[3]);
    }
}