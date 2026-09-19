public class Solution {
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var sDic = CountCharInString(s);
        var tDic = CountCharInString(t);

        if (sDic.Count != tDic.Count)
        {
            return false;
        }

        foreach (var sItem in sDic)
        {
            if (!tDic.TryGetValue(sItem.Key, out var tValue) 
                || tValue != sItem.Value)
            {
                return false;
            }
        }

        return true;
    }

    public Dictionary<char, int> CountCharInString(string inputStr)
    {
        var dic = new Dictionary<char, int>();

        foreach (var c in inputStr)
        {
            if (dic.ContainsKey(c))
            {
                dic[c]++;
            }
            else
            {
                dic.Add(c, 0);
            }
        }

        return dic;
    }
}
