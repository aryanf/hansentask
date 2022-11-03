namespace HansenTests;

using HansenCore;

public class ArgParserTests
{
    private HansenArgParser _parser;

    public ArgParserTests()
    {
        // pass
    }

    [Theory]
    [InlineData("")]
    [InlineData("srw")]
    [InlineData("fe r4")]
    [InlineData("fe 4 drk")]
    [InlineData("SSTS")]
    public void ArgNotParsedTests(string value)
    {
        _parser = new HansenArgParser(value.Split(' ').ToArray());
        _parser.Parse();
        Assert.False(_parser.Parsed());
    }

    [Theory]
    [InlineData("srw 3")]
    [InlineData("fe 4 43")]
    [InlineData("SSTST 2")]
    public void ArgParsedTests(string value)
    {
        _parser = new HansenArgParser(value.Split(' ').ToArray());
        _parser.Parse();
        Assert.True(_parser.Parsed());
    }

    [Theory]
    [InlineData("")]
    [InlineData("srw")]
    [InlineData("43")]
    public void NoEnoughtArgsTests(string value)
    {
        _parser = new HansenArgParser(value.Split(' ').ToArray());
        _parser.Parse();
        Assert.False(_parser.Parsed());
        Assert.Equal("Not enough argument to take pattern and numbers.", _parser.GetError());
    }

    [Theory]
    [InlineData("srw e")]
    [InlineData("SSTS 2 s")]
    [InlineData("SSTS 2 4 r")]
    [InlineData("awdw 1 5 rsfs")]
    public void NumberCastArgsTests(string value)
    {
        _parser = new HansenArgParser(value.Split(' ').ToArray());
        _parser.Parse();
        Assert.False(_parser.Parsed());
        Assert.Equal("All arguments after first arg should be number.", _parser.GetError());
    }
}
