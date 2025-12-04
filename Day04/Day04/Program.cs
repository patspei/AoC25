// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

string[] lines = File.ReadAllLines("../../../input.txt");
char[,] originalArray = new char[lines[0].Length, lines.Length];
char[,] newArray = new char[lines[0].Length, lines.Length];
WriteInputInArray();

int solution = 0;
int removed;

do
{
    removed = 0;
    for (int y = 0; y < lines.Length; y++)
    {
        CheckOneLine(originalArray, y);
    }

    Console.WriteLine(removed);
    PrintArray(newArray);
    solution += removed;
    Array.Copy(newArray, originalArray, newArray.Length);
} while (removed > 0);

Console.WriteLine($"Solution: {solution}");


// Methods:

void WriteInputInArray()
{
    for (int x = 0; x < lines[0].Length; x++)
    {
        for (int y = 0; y < lines.Length; y++)
        {
            originalArray[x, y] = lines[y][x];
        }
    }
}

void CheckOneLine(char[,] array, int y)
{
    for (int x = 0; x < array.GetLength(1); x++)
    {
        if (array[x, y] == 'x')
        {
            newArray[x, y] = '.';
        }

        if (array[x, y] == '@')
        {
            CheckOneCharacter(array, x, y);
        }
        else
        {
            newArray[x, y] = '.';
        }
    }
}

void CheckOneCharacter(char[,] array, int x, int y)
{
    int countAdjacents = 0;

    countAdjacents += CheckOnePosition(array, x - 1, y - 1);
    countAdjacents += CheckOnePosition(array, x, y - 1);
    countAdjacents += CheckOnePosition(array, x + 1, y - 1);

    countAdjacents += CheckOnePosition(array, x - 1, y);
    countAdjacents += CheckOnePosition(array, x + 1, y);

    countAdjacents += CheckOnePosition(array, x - 1, y + 1);
    countAdjacents += CheckOnePosition(array, x, y + 1);
    countAdjacents += CheckOnePosition(array, x + 1, y + 1);

    if (countAdjacents < 4)
    {
        removed++;
        newArray[x, y] = 'x';
    }
    else
    {
        newArray[x, y] = '@';
    }
}

int CheckOnePosition(char[,] array, int x, int y)
{
    try
    {
        if (array[x,y] == '@')
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


void PrintArray(char[,] array)
{
    for (int y = 0; y < array.GetLength(1); y++)
    {
        for (int x = 0; x < array.GetLength(0); x++)
        {
            Console.Write(array[x, y]);
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}
