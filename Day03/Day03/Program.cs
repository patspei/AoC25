
using System.Collections.Generic;

string[] lines = File.ReadAllLines("../../../input.txt");

long solutionA = 0;
long solutionB = 0;

foreach (var line in lines)
{
    List<int> lineIntList = MakeIntList(line);

    solutionA += ExtractHighestXDigitNumber(lineIntList, 2);
    solutionB += ExtractHighestXDigitNumber(lineIntList, 12);
}

Console.WriteLine($"SolutionA: {solutionA}");
Console.WriteLine($"SolutionB: {solutionB}");

List<int> MakeIntList(string line)
{
    List<int> returnList = new();
    foreach (var item in line)
    {
        returnList.Add(int.Parse(item.ToString()));
    }

    return returnList;
}

long ExtractHighestXDigitNumber(List<int> lineIntList, int digits)
{
    int startIndex = 0;
    int distanceToEnd = digits - 1;

    int[] resultDigits = new int[digits];

    for (int i = 0; i < resultDigits.Length; i++)
    {
        (int digit, startIndex) = ExtractOneDigit(lineIntList, startIndex, distanceToEnd);
        resultDigits[i] = digit;
        startIndex++;
        distanceToEnd--;
    }

    return AddDigitSums(resultDigits);
}

(int, int) ExtractOneDigit(List<int> lineIntList, int startIndex, int distanceToEnd)
{
    int digit = 0;
    int onIndex = 0;
    for (int i = startIndex; i < lineIntList.Count - distanceToEnd; i++)
    {
        if (lineIntList[i] > digit)
        {
            digit = lineIntList[i];
            onIndex = i;
        }
    }

    return (digit, onIndex);
}

long AddDigitSums(int[] solution)
{
    long result = 0;

    for (int i = 0; i < solution.Length; i++)
    {
        result += solution[i] * (long)Math.Pow(10, solution.Length - i - 1);
    }

    return result;
}
