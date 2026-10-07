public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var result = new int[k][];
        var minHeap = new PriorityQueue<int[], double>();
        for (int i = 0; i < points.Length; i++)
        {
            minHeap.Enqueue(points[i], GetDistance(points[i]));
        }

        while (k > 0)
        {
            result[^k] = minHeap.Dequeue();
            k--;
        }

        return result;
    }

    private static double GetDistance(int[] points)
    {
        return Math.Sqrt(Math.Pow(points[0], 2) + Math.Pow(points[1], 2));
    }
}
