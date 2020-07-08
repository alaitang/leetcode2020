public class Solution {
    public int FindPairs(int[] nums, int k) {
        if(k < 0)
            return 0;
        var result = 0;
        Dictionary<int, int> mapping = nums.GroupBy(x => x).ToDictionary(x=>x.Key, x => x.Count());
        if(k == 0){
            return mapping.Where(x=>x.Value >= 2).Count();
        }else{
            nums = nums.Distinct().ToArray();
            foreach(var item in nums ){
                if(mapping.ContainsKey(item+k))
                {
                    result++;
                }
                if(mapping.ContainsKey(item-k))
                {
                    result++;
                }
                mapping.Remove(item);
            }
        }
        
        return result;
    }
}