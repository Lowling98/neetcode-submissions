public class Solution {
    public bool IsValid(string s)
    {
        var dicClose = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        var hashOpen = new HashSet<char>
        {
            '(',
            '[',
            '{'
        };

        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (hashOpen.Contains(c))
            {
                stack.Push(c);
                continue;
            }

            if (dicClose.TryGetValue(c, out var open))
            {
                if (!stack.TryPeek(out var res)
                    || open != res)
                {
                    return false;
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        return stack.Count == 0;
    }
}
