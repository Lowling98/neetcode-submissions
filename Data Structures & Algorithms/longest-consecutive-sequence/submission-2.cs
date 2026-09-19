public class Solution {
    public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0)
            return 0;
        nums = nums.Order().ToArray();

        var max = 1;
        var temp = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                continue;
            }

            if (nums[i] - nums[i - 1] == 1)
            {
                temp++;
            }
            else
            {
                max = temp > max ? temp : max;
                temp = 1;
            }
        }

        return temp > max ? temp : max;
    }
}
