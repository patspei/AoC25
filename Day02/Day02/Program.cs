string input = File.ReadAllText("../../../input.txt");
string[] ranges = input.Split(',');

long sumOfInvalidIds = 0;

foreach (string range in ranges)
{
    string[] endpoints = range.Split("-");
    long from = long.Parse(endpoints[0]);
    long to = long.Parse(endpoints[1]);

    for (long i = from; i <= to; i++)
    {
        CheckOneID(i.ToString());
    }
}

void CheckOneID(string id)
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

    sumOfInvalidIds += long.Parse(id);
}

Console.WriteLine(sumOfInvalidIds);
