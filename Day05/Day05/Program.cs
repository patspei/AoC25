
string completeInput = File.ReadAllText("../../../input.txt");
string[] splittedInput = completeInput.Split("\r\n\r\n");

string[] ranges = splittedInput[0].Split("\r\n");
string[] ids = splittedInput[1].Split("\r\n");

List<AllowedRange> allowedIds = CreateListForValidRanges(ranges);
List<long> idsToCheck = CreateListForIdsToCheck(ids);

CheckAllIdsPartA();


// Methods:

List<AllowedRange> CreateListForValidRanges(string[] ranges)
{
    List<AllowedRange> allowedIds = new List<AllowedRange>();

    foreach (string range in ranges)
    {
        var allowed = ExtractFromAndTo(range);
        allowedIds.Add(allowed);
    }

    return allowedIds;
}

AllowedRange ExtractFromAndTo(string range)
{
    string[] splitted = range.Split('-');
    long from = long.Parse(splitted[0]);
    long to = long.Parse(splitted[1]);

    return new AllowedRange()
    {
        From = from,
        To = to
    };
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
    }

    return idsToCheck;
}

void CheckAllIdsPartA()
{
    long solutionA = 0;

    foreach (long id in idsToCheck)
    {
        foreach (var range in allowedIds)
        {
            if (id >= range.From && id <= range.To)
            {
                solutionA++;
                break;
            }
        }
    }

    Console.WriteLine($"Solution A: {solutionA}");
}
