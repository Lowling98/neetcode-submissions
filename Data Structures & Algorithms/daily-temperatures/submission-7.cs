public class Solution {
    public int[] DailyTemperatures(int[] temperatures)
    {
        var arr = new int[temperatures.Length];
        var kIndex = -1;
        for (int i = 1; i < temperatures.Length; i++)
        {
            if (temperatures[i] > temperatures[0])
            {
                arr[0] = i;
                kIndex = i;
                break;
            }
        }

        kIndex = kIndex == -1 ? temperatures.Length - 1 : kIndex;

        FindK(temperatures, 1, kIndex, ref arr);

        return arr;
    }

    private static void FindK(int[] temperatures, int index, int kIndex, ref int[] arr)
    {
        if (index >= temperatures.Length)
            return;

        if (temperatures[index] == temperatures[index - 1] && kIndex > index)
        {
            arr[index] = Math.Max(arr[index - 1] - 1, 0);
            FindK(temperatures, index + 1, kIndex, ref arr);
            return;
        }

        var (start, to) = temperatures[index] < temperatures[index - 1] && kIndex > index
                            ? (index + 1, kIndex)
                            : (kIndex + 1, temperatures.Length - 1);


        var newKIndex = -1;
        // Console.WriteLine("Start: {0}, To: {1}", start, to);
        for (int i = start; i <= to; i++)
        {
            if (temperatures[i] > temperatures[index])
            {                
                // Console.WriteLine("i: {0}-{1}, index: {2}-{3}", i, temperatures[i], index, temperatures[index]);

                arr[index] = i - index;
                newKIndex = i;
                break;
            }
        }

        newKIndex = newKIndex == -1 ? temperatures.Length - 1 : newKIndex;
        FindK(temperatures, index + 1, newKIndex, ref arr);
    }
}
