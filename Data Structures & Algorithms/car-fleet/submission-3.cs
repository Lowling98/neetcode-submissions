public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var minHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < position.Length; i++)
        {
            minHeap.Enqueue(speed[i], position[i]);
        }

        var expectedCompletedTime = new double[position.Length];
        for (var index = 0; minHeap.TryDequeue(out int spd, out int pos); index++)
        {
            expectedCompletedTime[index] = (double)(target - pos) / spd;
            // Console.WriteLine("Pos: {0}, Spd: {1}, expTime: {2}", pos, spd, expectedCompletedTime[index]);
        }

        var range = new double[2];
        range[0] = expectedCompletedTime[^1];
        range[1] = 0;
        var fleet = 1;
        // Console.WriteLine(string.Join(',', expectedCompletedTime));

        for (int i = expectedCompletedTime.Length-2; i >= 0; i--)
        {
            if (expectedCompletedTime[i] <= range[0]
                || expectedCompletedTime[i] <= range[1])
            {
                continue;
            }

            if (expectedCompletedTime[i] > range[1])
            {
                fleet++;
                range[1] = expectedCompletedTime[i];
                continue;
            }
        }

        return fleet;
    }
}
