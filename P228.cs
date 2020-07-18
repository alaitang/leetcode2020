public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        var result = new List<string>();
        
        var len = nums.Length;
        if(len == 0)
            return result;
        
        var low = nums[0];
        var high = nums[0];
        for(int i = 1;i<len;i++){
            if(nums[i] != high+1){
                if(low == high)
                    result.Add($"{low}");
                else
                    result.Add($"{low}->{high}");
                low = nums[i];
            }
            high = nums[i];
        }
        
        result.Add(low == high ? $"{low}" : $"{low}->{high}");
        
        return result;
    }
}