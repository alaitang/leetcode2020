public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        var result = 0;
        
        var low = 0;
        long r = nums[0];
        if(r < k)
            result++;
        
        for(int i = 1;i<nums.Length;i++){
            r*=nums[i];
            
            while(low <= i && r >= k){
                r/=nums[low++];
            }
            
            if(i >= low)
                result += i-low+1;
        }
        return result;
    }
}