namespace HansenInterface;

public interface ISoftToughMaker
{
    void MakeSoftTough();
    bool Validated();
    List<string> GetErrors();
    string GetResult();
}
