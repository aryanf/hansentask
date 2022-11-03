namespace HansenInterface;

public interface IArgParser
{
    void Parse();
    string GetPattern();
    List<int> GetNumbers();
    bool Parsed();
    string GetError();
}
