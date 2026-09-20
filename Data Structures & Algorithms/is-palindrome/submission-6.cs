public class Solution {
    public bool IsPalindrome(string s)
    {
        if (s?.Length == 0)
        {
            return true;
        }

        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            if (!IsValidLowCharacter(s[left], out var cLeft))
            {
                left++;
                continue;
            }

            if (!IsValidLowCharacter(s[right], out var cRight))
            {
                right--;
                continue;
            }

            if (cLeft != cRight)
            {
                Console.WriteLine("{0} and {1}", cLeft, cRight);
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    private bool IsValidLowCharacter(char c, out char? e)
    {
        e = null;
        if ((c >= 48 && c <= 57)
            || (c >= 65 && c <= 90))
        {
            e = c;
            return true;
        }

        if (c >= 97 && c <= 122)
        {
            e = (char)(c - ' ');
            return true;
        }

        return false;
    }
}
