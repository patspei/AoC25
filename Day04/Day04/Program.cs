// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

string[] lines = File.ReadAllLines("../../../input.txt");
char[,] input = new char[lines[0].Length, lines.Length];
WriteInputInArray();

int solution = 0;

CheckOneLine(0);

for (int y = 1; y < lines.Length; y++)
{
    CheckOneLine(y);
}

Console.WriteLine($"Solution: {solution}");



// Methods:

void WriteInputInArray()
{
    for (int x = 0; x < lines[0].Length; x++)
    {
        for (int y = 0; y < lines.Length; y++)
        {
            input[x, y] = lines[y][x];
        }
    }
}

void CheckOneLine(int y)
{
    for (int x = 0; x < input.GetLength(1); x++)
    {
        if (input[x, y] == '@')
        {
            CheckOneCharacter(x, y);
        }
    }
}

void CheckOneCharacter(int x, int y)
{
    int countAdjacents = 0;

    countAdjacents += CheckOnePosition(x - 1, y - 1);
    countAdjacents += CheckOnePosition(x, y - 1);
    countAdjacents += CheckOnePosition(x + 1, y - 1);

    countAdjacents += CheckOnePosition(x - 1, y);
    countAdjacents += CheckOnePosition(x + 1, y);

    countAdjacents += CheckOnePosition(x - 1, y + 1);
    countAdjacents += CheckOnePosition(x, y + 1);
    countAdjacents += CheckOnePosition(x + 1, y + 1);

    if (countAdjacents < 4)
    {
        solution++;
    }
}

int CheckOnePosition(int x, int y)
{
    try
    {
        if (input[x,y] == '@')
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
