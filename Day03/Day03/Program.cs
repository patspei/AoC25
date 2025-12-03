


string[] lines = File.ReadAllLines("../../../input.txt");

long solutionA = 0;

foreach (var line in lines)
{
    List<int> lineIntList = MakeIntList(line);
    int joltage = ExtractHighestNumber(lineIntList);
    // Console.WriteLine($"{line} => {joltage}");
    solutionA += joltage;
}

Console.WriteLine($"SolutionA: {solutionA}");

List<int> MakeIntList(string line)
{
    List<int> returnList = new();
    foreach (var item in line)
    {
        returnList.Add(int.Parse(item.ToString()));
    }

    return returnList;
}

int ExtractHighestNumber(List<int> lineIntList)
{
    int first = 0;
    int second = 0;

    int startIndexForSecond = 0;

    for (int i = 0; i < lineIntList.Count - 1; i++)
    {
        if (lineIntList[i] > first)
        {
            first = lineIntList[i];
            startIndexForSecond = i + 1;
        }
    }

    for (int j = startIndexForSecond; j < lineIntList.Count; j++)
    {
        if (lineIntList[j] > second)
        {
            second = lineIntList[j];
        }
    }

    return first * 10 + second;
}

