public class Solution {
    public bool Search(int[] nums, int target) {
        var low = 0;
        var high = nums.Length-1;
        if(high <0)
            return false;
        
        while(low < high-1){
            if(nums[low] == target || nums[high] == target)
                return true;
            
            if(nums[low] == nums[high])
            {
                low++;
                continue;
            }
            
            var mid = (low+high)/2;
            if(nums[low] < nums[mid]){
                if(nums[low] <= target && target <= nums[mid])
                    high = mid;
                else
                    low = mid;
            }else if(nums[mid] <= nums[high]){
                if(nums[mid] <= target && target <= nums[high])
                    low = mid;
                else
                    high = mid;
            }else{
                low++;
            }
        }
        
        return nums[low] == target || nums[high] == target;
    }
}