public class Solution {
    public int Reverse(int x)
    {
        var queue = new Queue<int>();
        var isPositive = x > 0;
        while (x != 0)
        {
            queue.Enqueue(Math.Abs(x % 10));
            if (queue.Peek() * Math.Pow(10, queue.Count - 1) > int.MaxValue)
            {
                return 0;
            }

            x /= 10;
        }

        var res = 0;
        while (queue.TryDequeue(out var val))
        {
            val *= (int)Math.Pow(10, queue.Count);
            if (int.MaxValue - res < val )
            {
                return 0;
            }

            res += val;
        }

        return isPositive ? res : -1 * res;
    }
}
