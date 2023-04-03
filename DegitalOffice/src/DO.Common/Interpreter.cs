namespace DO.Common;

public class Interpreter
{
    private readonly char start;
    private readonly char deliminator;
    private readonly char end;

    public Interpreter(char start, char deliminator, char end)
    {
        this.start = start;
        this.deliminator = deliminator;
        this.end = end;
    }

    public IList<KeyValuePair<string, string>> Parse(string rawString)
    {
        var result = new List<KeyValuePair<string, string>>();
        IList<char> key = null;
        IList<char> value = null;
        bool isKey = false, isValue = false;
        int sCounter = 0, eCounter = 0;

        foreach (var c in rawString)
        {
            if (c.Equals(start))
            {
                ++sCounter;

                if (sCounter == eCounter + 1)
                {
                    isKey = true;
                    key = new List<char>();
                    continue;
                }
            }

            if (c.Equals(deliminator) && isKey && sCounter == eCounter + 1)
            {
                isKey = false;
                isValue = true;
                value = new List<char>();
                continue;
            }

            if (c.Equals(end))
            {
                ++eCounter;

                if (sCounter == eCounter)
                {
                    result.Add(new KeyValuePair<string, string>(new string(key.ToArray()), new string(value.ToArray())));
                    continue;
                }
            }

            if (isKey)
                key.Add(c);
            if (isValue)
                value.Add(c);
        }

        return result;
    }
}
