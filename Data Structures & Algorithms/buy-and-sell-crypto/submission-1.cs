public class Solution {
    public int MaxProfit(int[] prices)
    {
        var temp = 0;
        var max = 0;
        for (int i = 0; i < prices.Length - 1; i++)
        {
            for (int j = i+1; j < prices.Length; j++)
            {
                temp = prices[j] - prices[i];
                max = Math.Max(temp, max);
            }
        }

        return Math.Max(0, max);
    }
}
