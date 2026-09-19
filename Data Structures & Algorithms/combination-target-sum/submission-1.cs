public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        var baseArr = new List<(int number, List<int> arr, int sum, int index)>();
        var result = new List<List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            var div = target / nums[i];

            for (int j = 1; j < div; j++)
            {
                var arr = new int[j];
                Array.Fill(arr, nums[i]);
                baseArr.Add((nums[i], arr.ToList(), arr.Sum(), i));
            }

            if (target % nums[i] > 0)
            {
                var arr = new int[div];
                Array.Fill(arr, nums[i]);
                baseArr.Add((nums[i], arr.ToList(), arr.Sum(), i));
            }
            else
            {
                var arr = new int[div];
                Array.Fill(arr, nums[i]);
                result.Add(arr.ToList());
            }
        }

        var k = 1;
        var temp = baseArr.Select(p => (hash: new HashSet<int>() { p.number }, p.arr, p.sum, lastIndex: p.index)).ToList();

        while (k <= nums.Length)
        {

            var stepK = new List<(HashSet<int> hash, List<int> arr, int sum, int lastIndex)>();
            foreach (var t in temp)
            {
                foreach (var b in baseArr.Where(p => p.index >= t.lastIndex))
                {
                    if (t.hash.Contains(b.number) || t.sum + b.sum > target)
                    {
                        continue;
                    }

                    var arrTemp = t.arr.ToList();
                    arrTemp.AddRange(b.arr);

                    if (t.sum + b.sum == target)
                    {
                        result.Add(arrTemp);
                    }

                    if (t.sum + b.sum < target)
                    {
                        var hash = t.hash.ToHashSet();
                        hash.Add(b.number);

                        stepK.Add((hash, arrTemp, t.sum + b.sum, b.index));
                    }
                }
            }

            temp = stepK;
            k++;
        }

        return result;
    }

}
