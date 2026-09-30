public class KthLargest {
    private readonly List<int> nums = new List<int>();
    private readonly int k = 0;
    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        Array.Sort(nums);
        this.nums = [.. nums];
    }

    public int Add(int val)
    {
        var currentKthIndex = nums.Count == 0
                                    ? -1
                                    : nums.Count >= k
                                        ? nums.Count - k
                                        : 0;
        // Console.WriteLine("currentKthIndex: {0}", currentKthIndex);

        var currentKth = currentKthIndex == -1 ? -1 : nums[currentKthIndex];
        // Console.WriteLine("currentKth: {0}", currentKth);


        if (val < currentKth)
        {
            return currentKth;
        }

        int i = currentKthIndex+1;

        for (; i < nums.Count; i++)
        {
            if (val <= nums[i])
            {
                break;
            }
        }

        nums.Insert(i, val);

        // Console.WriteLine(string.Join(',', nums));

        return nums[nums.Count >= k ? nums.Count - k : 0];
    }
}
