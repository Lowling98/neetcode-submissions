public class Solution {
    const string Separator = "あ";

    public string Encode(IList<string> strs)
    {
        var result = Separator;

        foreach (var item in strs)
        {
            result = $"{result}{item}{Separator}";
        }

        return result;
    }

    public List<string> Decode(string s)
    {
        var result = new List<string>();
        var temp = string.Empty;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == Separator[0])
            {
                result.Add(temp);
                temp = string.Empty;
                continue;
            }

            temp = $"{temp}{s[i]}";
        }

        return result;
    }
}
