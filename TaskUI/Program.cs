// See https://aka.ms/new-console-template for more information
using HansenCore;
using CommandLine;
using HansenInterface;

class Program
{
    static void Main(string[] args)
    {
        IArgParser parser = new HansenArgParser(args);
        parser.Parse();
        if (parser.Parsed())
        {
            ISoftToughMaker maker = new HansenSoftToughMaker(
                parser.GetPattern(),
                parser.GetNumbers()
            );
            maker.MakeSoftTough();
        }
        else
        {
            System.Console.WriteLine(parser.GetError());
        }
    }
}
