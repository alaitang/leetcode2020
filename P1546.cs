public class Solution {
    public int MaxNonOverlapping(int[] nums, int target) {
        var result = 0;
        
        var mapping = new HashSet<long>(){0};
        
        long sum = 0;
        foreach(var item in nums){
            sum+= item;
            if(mapping.Contains(sum-target))
            {
                result++;
                sum = 0;
                mapping = new HashSet<long>(){0};
            }else
            {
                mapping.Add(sum);
            }
            
        }
        
        return result;
        
    }
}