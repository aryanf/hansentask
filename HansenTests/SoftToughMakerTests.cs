namespace HansenTests;

using HansenCore;

public class SoftToughMakerTests
{
    private HansenSoftToughMaker _maker;

    public SoftToughMakerTests()
    {
        // pass
    }

    [Theory]
    [InlineData("SSTS", "3 8 2 32")]
    [InlineData("SST", "3 2")]
    [InlineData("T", "1")]
    public void ValidatedParametersTests(string pattern, string numbers)
    {
        HansenSoftToughMaker _maker = new HansenSoftToughMaker(
            pattern,
            numbers.Split(" ").Select(int.Parse).ToList()
        );
        _maker.MakeSoftTough();
        Assert.True(_maker.Validated());
    }

    [Theory]
    [InlineData("SsSTS", "3 8 2 32")]
    [InlineData("INDi", "3 2")]
    public void NotValidatedPatternTests(string pattern, string numbers)
    {
        HansenSoftToughMaker _maker = new HansenSoftToughMaker(
            pattern,
            numbers.Split(" ").Select(int.Parse).ToList()
        );
        _maker.MakeSoftTough();
        Assert.False(_maker.Validated());
        Assert.Equal("Pattern should only contains S or T character.", _maker.GetErrors()[0]);
    }

    [Theory]
    [InlineData("SSTSSTS")]
    [InlineData("S")]
    public void NotEnoughNumbersTests(string pattern)
    {
        HansenSoftToughMaker _maker = new HansenSoftToughMaker(pattern, new List<int>());
        _maker.MakeSoftTough();
        Assert.False(_maker.Validated());
        Assert.Equal("There should be at least one number argument.", _maker.GetErrors()[0]);
    }

    [Theory]
    [InlineData("SSseSSTS")]
    [InlineData("Sl")]
    public void TwoValidationErrorTests(string pattern)
    {
        HansenSoftToughMaker _maker = new HansenSoftToughMaker(pattern, new List<int>());
        _maker.MakeSoftTough();
        Assert.False(_maker.Validated());
        Assert.Equal("Pattern should only contains S or T character.", _maker.GetErrors()[0]);
        Assert.Equal("There should be at least one number argument.", _maker.GetErrors()[1]);
    }

    [Theory]
    [InlineData("SSTSSTS")]
    [InlineData("S")]
    public void OutputTest1(string pattern)
    {
        HansenSoftToughMaker _maker = new HansenSoftToughMaker(pattern, new List<int>() { 0 });
        _maker.MakeSoftTough();
        Assert.True(_maker.Validated());
        Assert.Equal("\n", _maker.GetResult());
    }

    [Theory]
    [InlineData("SSTSSTS")]
    [InlineData("S")]
    public void OutputTest2(string pattern)
    {
        HansenSoftToughMaker _maker = new HansenSoftToughMaker(pattern, new List<int>() { 1 });
        _maker.MakeSoftTough();
        Assert.True(_maker.Validated());
        Assert.Equal("Soft.\n", _maker.GetResult());
    }

    [Theory]
    [InlineData("SSTSSTS")]
    [InlineData("SST")]
    public void OutputTest3(string pattern)
    {
        HansenSoftToughMaker _maker = new HansenSoftToughMaker(
            pattern,
            new List<int>() { 2, 1, 3, 7 }
        );
        _maker.MakeSoftTough();
        Assert.True(_maker.Validated());
        string expected =
            "Soft and Soft.\nSoft.\nSoft, Soft and Tough.\nSoft, Soft, Tough, Soft, Soft, Tough and Soft.\n";
        Assert.Equal(expected, _maker.GetResult());
    }
}
