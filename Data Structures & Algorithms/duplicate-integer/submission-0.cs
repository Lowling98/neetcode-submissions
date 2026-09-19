public class Solution {
    public bool hasDuplicate(int[] nums) {
        var hs = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (hs.Contains(nums[i]))
            {
                return true;
            }

            hs.Add(nums[i]);
        }

        return false;
    }
}