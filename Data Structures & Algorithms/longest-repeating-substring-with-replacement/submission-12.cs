public class Solution {
    public int CharacterReplacement(string s, int k) {
        int nextI = -1;
        var currentC = s[0];
        var max = 1;
        var countDiff = 0;
        var tempMax = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (currentC == s[i])
            {
                tempMax++;

                if (i + 1 == s.Length)
                {
                    if (max < tempMax)
                    {
                        max = tempMax;
                    }

                    if (nextI != -1)
                    {
                        i = nextI;
                        currentC = s[nextI];
                        countDiff = 0;
                        nextI = -1;
                        tempMax = 1;
                    }
                }
            }
            else
            {
                if (nextI == -1)
                {
                    nextI = i;
                }

                countDiff++;
                if (countDiff > k || i + 1 == s.Length)
                {
                    if (max < tempMax)
                    {
                        max = tempMax;
                    }

                    i = nextI;
                    currentC = s[nextI];
                    countDiff = 0;
                    nextI = -1;
                    tempMax = 1;
                }
            }
        }

        max += k;

        return max > s.Length ? s.Length : max;
    }
}
