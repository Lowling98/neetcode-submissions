public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs)
    {
        var skipString = "A";
        var emptyCount = 0;

        var result = new List<List<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            if (strs[i] == skipString)
            {
                continue;
            }

            if (strs[i] == string.Empty)
            {
                emptyCount++;
                continue;
            }

            var l = new List<string>() { strs[i] };

            for (int j = i + 1; j < strs.Length; j++)
            {
                if (strs[j] == skipString)
                {
                    continue;
                }

                if (IsAnagram(strs[i], strs[j]))
                {
                    l.Add(strs[j]);
                    strs[j] = skipString;
                }
            }

            result.Add(l);
        }

        if (emptyCount > 0)
        {
            var e = new string[emptyCount];
            Array.Fill(e, string.Empty);
            result.Add(e.ToList());
        }

        return result;
    }

    private bool IsAnagram(string s, string compare)
    {
        var compareArr = new int[27];
        var asciiConst = 97;

        foreach (var c in s)
        {
            compareArr[c - asciiConst]++;
        }

        foreach (var c in compare)
        {
            if (compareArr[c - asciiConst] == 0)
                return false;

            compareArr[c - asciiConst]--;
        }

        foreach (var value in compareArr)
        {
            if (value != 0)
            {
                return false;
            }
        }

        return true;
    }
}
