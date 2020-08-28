public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var mapping = new Dictionary<long,int>();
        long sum = 0 ;
        mapping.Add(0,1);
        var result = 0;
        foreach(var n in nums){
            sum+=n;
            if(mapping.ContainsKey(sum-k))
                result += mapping[sum-k];
            
            if(!mapping.ContainsKey(sum))
                mapping[sum] = 0;
            mapping[sum]++;
        }
        
        return result;
    }
}