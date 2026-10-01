public class Solution {
public bool CheckInclusion(string s1, string s2)
    {
        if (s2.Length < s1.Length)
        {
            return false;
        }

        var dic1 = new Dictionary<char, int>();
        var dic2 = new Dictionary<char, int>();
        var sum = 0;
        foreach (var c in s1)
        {
            if (!dic1.TryAdd(c, 1))
            {
                dic1[c]++;
            }

            sum += c;
        }
            // Console.WriteLine("sum:{0}", sum);

        var kSum = s2[..s1.Length].Sum(p => (int)p);
        Console.WriteLine(string.Join(',', dic1.Select(p => $"{p.Key}:{p.Value}")));

        for (int i = 0; i <= s2.Length - s1.Length; i++)
        {
            (var pre, var next) = i == 0 ? (0, 0) : (s2[i - 1], s2[i + s1.Length-1]);
            kSum = kSum - pre + next;
            // Console.WriteLine("s:{0}, ksum: {1}", s2.Substring(i, s1.Length), kSum);

            if (kSum == sum)
            {
            // Console.WriteLine("s:{0}", s2.Substring(i, s1.Length));

                for (int j = i; j < i + s1.Length; j++)
                {
                    if (!dic1.TryGetValue(s2[j], out var val))
                    {
                        break;
                    }

                    if (!dic2.TryAdd(s2[j], 1))
                    {
                        dic2[s2[j]]++;
                    }

                    if (val < dic2[s2[j]])
                    {
                        break;
                    }
                }
        // Console.WriteLine(string.Join(',', dic2.Select(p => $"{p.Key}:{p.Value}")));

                var isValid = true;
                foreach (var item in dic1)
                {
                    if (dic2.Count != dic1.Count
                        || !dic2.TryGetValue(item.Key, out var val)
                        || val != item.Value)
                    {
                        dic2.Clear();
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    return true;
                }
            }
        }


        return false;
    }
}
