

// Super Slow, maybe instead of building lists: check if id is greater or equal than from and smaller or equal than to value of each range

string completeInput = File.ReadAllText("../../../input.txt");
string[] splittedInput = completeInput.Split("\r\n\r\n");

string[] ranges = splittedInput[0].Split("\r\n");
string[] ids = splittedInput[1].Split("\r\n");

Console.WriteLine($"Read input: {DateTime.Now}");

List<long> allowedIds = CreateListForValidIds(ranges);
Console.WriteLine($"Created list for valid ids: {DateTime.Now}");

List<long> idsToCheck = CreateListForIdsToCheck(ids);
Console.WriteLine($"Created list for ids to check: {DateTime.Now}");

CheckAllIdsPartA();


// Methods:

List<long> CreateListForValidIds(string[] ranges)
{
    List<long> allowedIds = new List<long>();

    foreach (string range in ranges)
    {
        AddToListIfNew(ExtractFromAndTo(range), allowedIds);
    }

    allowedIds.Sort();

    return allowedIds;
}

(long from, long to) ExtractFromAndTo(string range)
{
    string[] splitted = range.Split('-');
    long from = long.Parse(splitted[0]);
    long to = long.Parse(splitted[1]);

    return (from, to);
}

void AddToListIfNew((long from, long to) range, List<long> allowedIds)
{
    for (long i = range.from; i <= range.to; i++)
    {
        if (!allowedIds.Contains(i))
        {
            allowedIds.Add(i);
        }
    }
}

List<long> CreateListForIdsToCheck(string[] ids)
{
    List<long> idsToCheck = new List<long>();

    foreach (string id in ids)
    {
        if (id.IsWhiteSpace())
        {
            continue;
        }

        idsToCheck.Add(long.Parse(id));

        // Todo: maybee check for duplicates?
    }

    return idsToCheck;
}

void CheckAllIdsPartA()
{
    long solutionA = 0;

    foreach (long id in idsToCheck)
    {
        if (allowedIds.Contains(id))
        {
            solutionA++;
        }
    }

    Console.WriteLine($"Solution A: {solutionA}");
}
