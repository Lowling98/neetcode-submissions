public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
                return strs
        .Select(p => (compare: string.Join(string.Empty, p.Order()), original: p))
        .GroupBy(p => p.compare, p => p.original, (_, g) => g.ToList())
        .ToList();
    }
}
