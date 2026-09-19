public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var arr = new int[2001];
        int x = 1000;

        foreach (var value in nums)
        {
            arr[value + x]++;
        }

        var minHeap = new PriorityQueue<int, int>();


        for (int i = 0; i < arr.Length; i++)
        {
            if (arr.Length == 0)
                continue;

            minHeap.Enqueue(i - x, arr[i]);
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        var result = new int[k];

        for (int i = 0; i < k; i++)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
    }
}
