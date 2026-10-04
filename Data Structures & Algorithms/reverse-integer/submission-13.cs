public class Solution {
    public int Reverse(int x) {
                if (x <= int.MinValue || x >= int.MaxValue)
        {
            return 0;
        }
        var prefix = x >= 0 ? 1 : -1;
        var res = 0;
        for (int tenCount = 10; tenCount >= 0; tenCount--)
        {
            if (Math.Abs(x) >= Math.Pow(10, tenCount))
            {
                double val = Math.Abs(x % 10);
                val *= Math.Pow(10, tenCount);
                if (int.MaxValue - res < val)
                {
                    return 0;
                }

                res += (int)val;
                Console.WriteLine(res);
                x /= 10;
            }
        }

        return prefix * res;
    }
}
