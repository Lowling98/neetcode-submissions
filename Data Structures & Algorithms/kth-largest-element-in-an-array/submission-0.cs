public class Solution {
    public int FindKthLargest(int[] nums, int k) {
                var minHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            minHeap.Enqueue(i, 0 - nums[i]);
        }

        while (k > 1)
        {
            minHeap.Dequeue();
            k--;
        }

        return nums[minHeap.Dequeue()];
    }
}
