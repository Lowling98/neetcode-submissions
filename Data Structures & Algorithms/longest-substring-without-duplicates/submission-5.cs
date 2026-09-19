public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var max = 1;
        var arrAscll = new int[128];
        Array.Fill(arrAscll, -1);
        var tempMax = 0;
        var startFrom = 0;
        if (s == string.Empty)
            return 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (arrAscll[s[i]] == -1
             || arrAscll[s[i]] == i
             || arrAscll[s[i]] < startFrom)
            {
                tempMax++;
                arrAscll[s[i]] = i;

                                if (i + 1 == s.Length
                    && max < tempMax)
                {
                    return tempMax;
                }
            }
            else
            {
                if (max < tempMax)
                {
                    max = tempMax;
                }

                i = arrAscll[s[i]];
                arrAscll[s[i]] = -1;
                tempMax = 0;
                startFrom = i;
            }
        }

        return max;
    }
}
