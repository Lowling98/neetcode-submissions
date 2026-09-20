public class Solution {
    public int LongestConsecutive(int[] nums) {
        var dic = new Dictionary<int, int>();
        var max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.ContainsKey(nums[i]))
            {
                continue;
            }

            var isPrevious = dic.TryGetValue(nums[i] - 1, out var previous);
            var isNext = dic.TryGetValue(nums[i] + 1, out var next);

            var val = 1;
            val += isPrevious ? previous : 0;
            val += isNext ? next : 0;
            dic.Add(nums[i], val);

            if (isPrevious)
            {
                dic[nums[i] - previous] = val;
            }

            if (isNext)
            {
                dic[nums[i] + next] = val;
            }

            max = Math.Max(max, val);

        }

        return max;
    }
}