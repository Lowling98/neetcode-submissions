public class MinStack
{
    private readonly List<int> values = [];
    private readonly List<int> sortedValues = [];
    public MinStack()
    {

    }

    public void Push(int val)
    {
        values.Add(val);

        var i = 0;
        for (; i < sortedValues.Count; i++)
        {
            if (val < sortedValues[i])
            {
                break;
            }
        }

        sortedValues.Insert(i, val);

        // Console.WriteLine("===Push: {0}", val);
        // Console.WriteLine(string.Join(',', values));
        // Console.WriteLine(string.Join(',', sortedValues));
        // Console.WriteLine("===========");
    }

    public void Pop()
    {
        var latest = values[^1];
        values.RemoveAt(values.Count - 1);

        var i = 0;
        for (; i < sortedValues.Count; i++)
        {
            if (latest == sortedValues[i])
            {
                break;
            }
        }

        sortedValues.RemoveAt(i);

        // Console.WriteLine("===Pop: {0}", latest);
        // Console.WriteLine(string.Join(',', values));
        // Console.WriteLine(string.Join(',', sortedValues));
        // Console.WriteLine("===========");
    }

    public int Top()
    {
        // Console.WriteLine("===Top");
        // Console.WriteLine(string.Join(',', values));
        // Console.WriteLine(string.Join(',', sortedValues));
        // Console.WriteLine("===========");
        return values[^1];
    }

    public int GetMin()
    {
        // Console.WriteLine("===GetMin");
        // Console.WriteLine(string.Join(',', values));
        // Console.WriteLine(string.Join(',', sortedValues));
        // Console.WriteLine("===========");
        return sortedValues[0];
    }
}