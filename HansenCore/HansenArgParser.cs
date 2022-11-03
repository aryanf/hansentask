using System;
using CommandLine;
using HansenInterface;

namespace HansenCore
{
    public class HansenArgParser : IArgParser
    {
        private string _pattern;
        private List<int> _numbers;
        private bool _pattern_number_parsed;
        private string[] _args;
        private string _error;

        public HansenArgParser(string[] args)
        {
            _pattern = "";
            _numbers = new List<int>();
            _pattern_number_parsed = false;
            _args = args;
            _error = "";
        }

        public void Parse()
        {
            Parser.Default
                .ParseArguments<ArgOptions>(_args)
                .WithParsed<ArgOptions>(o =>
                {
                    if (o.Version)
                    {
                        Console.WriteLine("SoftToughMaker application version 1.0.0");
                    }
                    else if (o.Help)
                    {
                        Console.WriteLine(
                            "How to use SoftToughMaker application: \nFirst argument is pattern and rest of arguments are number to repeat the pattern."
                        );
                    }
                    else if (_args.Length < 2)
                    {
                        _error = "Not enough argument to take pattern and numbers.";
                    }
                    else
                    {
                        _pattern = _args[0];
                        var stringNumbers = _args.Skip(1).ToList();
                        int temp = 0;
                        if (stringNumbers.All(x => int.TryParse(x, out temp)))
                        {
                            _numbers = stringNumbers.Select(int.Parse).ToList();
                            _pattern_number_parsed = true;
                        }
                        else
                        {
                            _error = "All arguments after first arg should be number.";
                        }
                    }
                });
        }

        public string GetPattern()
        {
            return _pattern;
        }

        public List<int> GetNumbers()
        {
            return _numbers;
        }

        public bool Parsed()
        {
            return _pattern_number_parsed;
        }

        public string GetError()
        {
            return _error;
        }
    }
}
