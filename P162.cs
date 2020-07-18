public class Solution {
    public int FindPeakElement(int[] nums) {
        var low = 0;
        var high = nums.Length-1;
        var len = nums.Length;
        
        while(low < high-1){
            var mid = (low+high)/2;
            
            if(nums[mid-1] < nums[mid] && nums[mid] > nums[mid+1])
                return mid;
            else if(nums[mid-1] < nums[mid] && nums[mid] < nums[mid+1])
                low = mid;
            else
                high = mid;
        }
        
        if((low-1 < 0 || nums[low-1] < nums[low]) && (low +1 >= len || nums[low] > nums[low+1]) )
            return low;
        else
            return high;
    }
}