using savaged.NGram.Lib;

namespace savaged.NGram.Test;

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
        //Given searchQuery is: "Oak Furnitureland Group Limited"
        var searchQuery = "Oak Furnitureland Group Limited";
        //When split is run 
        var result = _nGramService.ToNGrams(searchQuery);
        //Then Result is a collection
        Assert.NotNull(result);
        //And 1st item in the collection is "Oak Furnitureland Group Limited"
        Assert.Equal("Oak Furnitureland Group Limited", result[0]);
        //And 2nd item in the collection is "Oak Furniture Land" 
        Assert.Equal("Oak Furnitureland Group", result[1]);
        //And 3rd item in the collection is "Oak Furniture"
        Assert.Equal("Oak Furnitureland", result[2]);
        //And 4th item in the collection is "Oak"
        Assert.Equal("Oak", result[3]);
    }
}