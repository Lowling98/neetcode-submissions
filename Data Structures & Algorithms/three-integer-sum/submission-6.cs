public class Solution {
    public List<List<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var dic = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!dic.TryAdd(n, 1))
            {
                dic[n]++;
            }
        }
        var dicResult = new Dictionary<string, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var k = 0 - (nums[i] + nums[j]);
                if (k < nums[i])
                {
                    continue;
                }

                if (dic.TryGetValue(k, out var value))
                {
                    if (k == nums[i])
                        value--;

                    if (k == nums[j])
                        value--;

                    if (value > 0)
                    {
                        var min = Math.Min(k, nums[j]);
                        var max = Math.Max(k, nums[j]);
                        dicResult.TryAdd($"{nums[i]},{min},{max}", [nums[i], min, max]);
                    }
                }
            }
        }

        // var result = new List<List<int>>();
        // DFS(dic, nums, 0, nums.Length - 1, ref result);
        return dicResult.Values.ToList();
    }
}
