public class Solution {
    public int TriangleNumber(int[] nums) {
        nums = nums.OrderBy(x=>x).ToArray();
        var len = nums.Length;
        var result = 0;
        for(int i = 0;i<len-2;i++){
            var low = i+1;
            var high = i+2;
            
            while(high < len){
                while(low < high && nums[high] - nums[low] >= nums[i]){
                    low++;
                }
                
                result += high-low;
                high++;
            }
        }
        
        return result;
    }
}