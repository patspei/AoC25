// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

string[] lines = File.ReadAllLines("../../../input.txt");
int length = lines[0].Length;

int solutionA = 0;

string last = new string('.', length);
string actual = lines[0];
string next = lines[1];

CheckOneLine(actual);

for (int i = 2; i < lines.Length + 1; i++)
{
    SetNewLines(i);
    CheckOneLine(actual);
}

Console.WriteLine($"SolutionA: {solutionA}");

void SetNewLines(int newIndex)
{
    last = actual;
    actual = next;

    if (newIndex == lines.Length)
    {
        next = new string('.', length);
    }
    else
    {
        next = lines[newIndex];
    }
}

void CheckOneLine(string line)
{
    for (int i = 0; i < line.Length; i++)
    {
        if (line[i] == '@')
        {
            CheckOneCharacter(i);
        }
    }
}

void CheckOneCharacter(int i)
{
    int countAdjacents = 0;

    countAdjacents += CheckOnePosition(last, i - 1);
    countAdjacents += CheckOnePosition(last, i);
    countAdjacents += CheckOnePosition(last, i + 1);

    countAdjacents += CheckOnePosition(actual, i - 1);
    countAdjacents += CheckOnePosition(actual, i + 1);

    countAdjacents += CheckOnePosition(next, i - 1);
    countAdjacents += CheckOnePosition(next, i);
    countAdjacents += CheckOnePosition(next, i + 1);

    if (countAdjacents < 4)
    {
        solutionA++;
    }
}

int CheckOnePosition(string list, int index)
{
    try
    {
        if (list[index] == '@')
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    catch (IndexOutOfRangeException)
    {
        return 0;
    }
}
