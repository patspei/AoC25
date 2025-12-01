


string input = File.ReadAllText("../../../input.txt");
string[] lines = input.Split("\r\n");

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

Console.WriteLine(zeroCounter);
