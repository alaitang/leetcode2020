public class Solution {
    public int Rob(int[] nums) {
        var len = nums.Length;
        
        if(len == 1)
            return nums[0];
        
        return Math.Max(Helper(nums,0,len-2),Helper(nums,1,len-1));
    }
    
    private int Helper(int[] nums,int low,int high){
        var result = nums[low];
        var r = nums[low];
        var r1 = 0;
        for(int i = low+1;i<=high;i++){
            var nextr1 = Math.Max(r1,r);
            r1 += nums[i];
            r = Math.Max(r,r1);
            result = Math.Max(result,r);
            r1 = nextr1;
        }
        
        return result;
    }
}