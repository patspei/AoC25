
// PART A:


string[] lines = File.ReadAllLines("../../../input.txt");

int zeroCounter = 0;
int actualNumber = 50;

foreach (string line in lines)
{
    if (line.StartsWith('L'))
    {
        int number = Extract(line);
        Subtract(number);
    }
    else
    {
        int number = Extract(line);
        Add(number);
    }
}

int Extract(string line)
{
    string numberedString = line.Remove(0, 1);
    return int.Parse(numberedString) % 100;
}

void Subtract(int number)
{
    actualNumber -= number;
    if (actualNumber == 0)
    {
        zeroCounter++;
    }

    if (actualNumber < 0)
    {
        actualNumber += 100;
    }
}
void Add(int number)
{
    actualNumber += number;
    if (actualNumber > 99)
    {
        actualNumber -= 100;
    }

    if (actualNumber == 0)
    {
        zeroCounter++;
    }
}

Console.WriteLine($"Solution A: {zeroCounter}");



// PART B:

actualNumber = 50;
zeroCounter = 0;

foreach (var line in lines)
{
    if (line.StartsWith('L'))
    {
        int number = ExtractWithoutModulo(line);
        GoLeft(number);
    }
    else
    {
        int number = ExtractWithoutModulo(line);
        GoRight(number);
    }
}

void GoRight(int number)
{
    for (int i = 0; i < number; i++)
    {
        DoOneStep(1);
    }
}

void GoLeft(int number)
{
    for (int i = 0; i < number; i++)
    {
        DoOneStep(-1);
    }
}

int ExtractWithoutModulo(string line)
{
    string numberedString = line.Remove(0, 1);
    return int.Parse(numberedString);
}

void DoOneStep(int amount)
{
    actualNumber += amount;
    if (actualNumber == 100)
    {
        actualNumber -= 100;
    }

    if (actualNumber == -1)
    {
        actualNumber += 100;
    }

    if (actualNumber == 0)
    {
        zeroCounter++;
    }
}

Console.WriteLine($"Solution B: {zeroCounter}");
