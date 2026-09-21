public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var left = 0;
        var right = numbers.Length - 1;
        while (left < right)
        {
            var temp = numbers[left] + numbers[right];
            if (temp == target)
            {
                return [left + 1, right + 1];
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
