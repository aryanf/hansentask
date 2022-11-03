using System;
using HansenInterface;

namespace HansenCore
{
    public class HansenSoftToughMaker : ISoftToughMaker
    {
        Dictionary<char, string> SoftToughDic = new Dictionary<char, string>()
        {
            { 'S', "Soft" },
            { 'T', "Tough" }
        };
        private string _pattern;
        private List<int> _numbers;
        private bool _pattern_validated;
        private bool _numbers_validated;
        private List<string> _errors;
        private string _result;

        public HansenSoftToughMaker(string pattern, List<int> numbers)
        {
            _pattern = pattern;
            _numbers = numbers;
            _pattern_validated = false;
            _numbers_validated = false;
            _errors = new List<string>();
            _result = "";
        }

        public void MakeSoftTough()
        {
            ValidatePattern();
            ValidateNumbers();
            if (Validated())
            {
                foreach (int num in _numbers)
                {
                    string resultTemp = "";
                    string repeatedPattern = _pattern;
                    while (repeatedPattern.Length < num)
                    {
                        repeatedPattern = repeatedPattern + repeatedPattern;
                    }
                    if (num <= 0)
                    {
                        resultTemp = "\n";
                    }
                    else if (num == 1)
                    {
                        resultTemp = SoftToughDic[repeatedPattern.ToCharArray()[0]] + ".\n";
                    }
                    else
                    {
                        List<string> temp1 = Enumerable
                            .Range(0, num - 1)
                            .Select(i => SoftToughDic[repeatedPattern.ToCharArray()[i]])
                            .ToList();
                        string temp2 = SoftToughDic[repeatedPattern.ToCharArray()[num - 1]];
                        resultTemp = String.Join(", ", temp1) + " and " + temp2 + ".\n";
                    }
                    _result = _result + resultTemp;
                }
                System.Console.WriteLine(GetResult());
            }
            else
            {
                foreach (string error in GetErrors())
                {
                    System.Console.WriteLine(error);
                }
            }
        }

        private void ValidatePattern()
        {
            if (_pattern.ToCharArray().Any(x => x != 'S' && x != 'T'))
            {
                _errors.Add("Pattern should only contains S or T character.");
                _pattern_validated = false;
            }
            else
            {
                _pattern_validated = true;
            }
        }

        private void ValidateNumbers()
        {
            if (_numbers.Count == 0)
            {
                _errors.Add("There should be at least one number argument.");
                _numbers_validated = false;
            }
            else
            {
                _numbers_validated = true;
            }
        }

        public bool Validated()
        {
            return _pattern_validated && _numbers_validated;
        }

        public List<string> GetErrors()
        {
            return _errors;
        }

        public string GetResult()
        {
            return _result;
        }
    }
}
