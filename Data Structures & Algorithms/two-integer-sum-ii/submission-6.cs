public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        var sorted = nums
            .Select((p, i) => (value: p, index: i))
            .OrderBy(p => p.value)
            .ToArray();

        var left = 0;
        var right = (sorted.Length - 1);
        while (left < right)
        {
            var temp = sorted[left].value + sorted[right].value;
            if (temp == target)
            {
                return sorted[left].index < sorted[right].index
                        ? [sorted[left].index+1, sorted[right].index+1]
                        : [sorted[right].index+1, sorted[left].index+1];
            }

            if (temp > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return [0, 0];
    }
}
