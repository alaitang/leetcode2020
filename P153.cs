public class Solution {
    public int FindMin(int[] nums) {
        var low = 0;
        var high = nums.Length-1;
        
        while(low < high-1){
            var mid = (low+high)/2;
            
            if(nums[low] < nums[high]){
                high = mid;
            }else if(nums[low] < nums[mid]){
                low = mid;
            }else{
                high = mid;
            }
        }
        
        return Math.Min(nums[low],nums[high]);
            
            
    }
}