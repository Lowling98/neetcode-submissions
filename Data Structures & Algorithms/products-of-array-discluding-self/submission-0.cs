public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        if (nums.Length == 0)
            return nums;

        var result = new int[nums.Length];

        var product = 1;
        var zeroIndex = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                if (zeroIndex == -1)
                {
                    zeroIndex = i;
                }
                else
                {
                    return new int[nums.Length];
                }

                continue;
            }

            product *= nums[i];
        }

        if (zeroIndex != -1)
        {
            result[zeroIndex] = product;
            return result;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = product / nums[i];
        }

        return result;
    }
}
