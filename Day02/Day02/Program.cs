
string input = File.ReadAllText("../../../input.txt");
string[] ranges = input.Split(',');

long sumOfInvalidIdsA = 0;
long sumOfInvalidIdsB = 0;

foreach (string range in ranges)
{
    string[] endpoints = range.Split("-");
    long from = long.Parse(endpoints[0]);
    long to = long.Parse(endpoints[1]);

    for (long i = from; i <= to; i++)
    {
        CheckOneIDPartA(i.ToString());
        CheckOneIDPartB(i.ToString());
    }
}

void CheckOneIDPartA(string id)
{
    if (id.Length % 2 != 0)
    {
        return;
    }

    for (int i = 0; i < id.Length / 2; i++)
    {
        if (id[i] != id[id.Length / 2 + i])
        {
            return;
        }
    }

    sumOfInvalidIdsA += long.Parse(id);
}

void CheckOneIDPartB(string id)
{
    if (id.Length < 2)
    {
        return;
    }

    if (id.Length == 2)
    {
        if (CheckSingleDigitRepeat(id))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 3)
    {
        if (CheckSingleDigitRepeat(id))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 4)
    {
        if (CheckSingleDigitRepeat(id) || CheckMultipleDigitRepeat(id, 2))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 5)
    {
        if (CheckSingleDigitRepeat(id))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 6)
    {
        if (CheckSingleDigitRepeat(id) || CheckMultipleDigitRepeat(id, 2) || CheckMultipleDigitRepeat(id, 3))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 7)
    {
        if (CheckSingleDigitRepeat(id))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 8)
    {
        if (CheckSingleDigitRepeat(id) || CheckMultipleDigitRepeat(id, 2) || CheckMultipleDigitRepeat(id, 4))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 9)
    {
        if (CheckSingleDigitRepeat(id) || CheckMultipleDigitRepeat(id, 3))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length == 10)
    {
        if (CheckSingleDigitRepeat(id) || CheckMultipleDigitRepeat(id, 2) || CheckMultipleDigitRepeat(id, 5))
        {
            sumOfInvalidIdsB += long.Parse(id);
        }
    }

    if (id.Length > 10)
    {
        Console.WriteLine("longer than 10");
    }
}

bool CheckSingleDigitRepeat(string id)
{
    char first = id[0];

    for (int i = 1; i < id.Length; i++)
    {
        if (first != id[i])
        {
            return false;
        }
    }

    return true;
}

bool CheckMultipleDigitRepeat(string id, int length)
{
    string first = id.Substring(0, length);

    for (int i = length; i < id.Length; i+= length)
    {
        if (first != id.Substring(i, length))
        {
            return false;
        }
    }

    return true;
}

Console.WriteLine(sumOfInvalidIdsA);
Console.WriteLine(sumOfInvalidIdsB);
