public class Solution {
    public int MaxArea(int[] height) {
        var max = -1;
        var left = 0;
        var right = height.Length - 1;
        var temp = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                temp = height[left] * (right - left);
                left++;
            }
            else
            {
                temp = height[right] * (right - left);
                right--;
            }

            if (temp > max)
            {
                max = temp;

            }
        }


        return max;
    }
}
