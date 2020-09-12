public class Solution {
    public int Search(int[] nums, int target) {
        var low = 0;
        var high = nums.Length-1;
        if(high < 0)
            return -1;
        else if(nums[low] == target)
            return low;
        else if(nums[high] == target)
            return high;
        
        while(low < high-1){
            var mid = (low+high)/2;
            if(nums[mid] == target)
                return mid;
            
            if(nums[low] < nums[mid]){
                if(nums[low] <= target && target <= nums[mid])
                    high = mid;
                else
                    low = mid;
            }else{
                if(nums[mid] <= target && target <= nums[high]){
                    low = mid;
                }else
                    high = mid;
            }
        }
        
        if(nums[low] == target)
            return low;
        else if(nums[high] == target)
            return high;
        else
            return -1;
    }
}