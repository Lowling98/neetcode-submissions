public class Solution {
    public int LastStoneWeight(int[] stones) {
                var minHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < stones.Length; i++)
        {
            minHeap.Enqueue(stones[i], 0-stones[i]);
        }

        while (minHeap.Count > 1)
        {
            var x =minHeap.Dequeue();
            var y =minHeap.Dequeue();
            var val = x - y;

            Console.WriteLine("{0}-{1}={2}", x, y, val);           
            minHeap.Enqueue(val, 0 - val);
        }

        return minHeap.Count == 0 ? 0 : minHeap.Dequeue();
    }
}
