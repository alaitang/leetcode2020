public class Solution {
    public bool Makesquare(int[] nums) {
        var sum = 0;
        var max = 0;
        foreach(var item in nums)
        {
            sum+=item;
            max = Math.Max(max,item);
        }
        var avg = sum/4;
        if(sum % 4 != 0 || sum == 0 || max > avg)
            return false;
        
        return Helper(nums,new int[4],avg,0,nums.Length);
    }
    
    private bool Helper(int[] nums,int[] dp,long avg,int index,int len){
        if(index >= len)
            return true;
        
        for(int i = 0;i<4;i++){
            if(i -1 >=0 && dp[i] == dp[i-1])
                continue;
            if(dp[i] + nums[index] <= avg){
                dp[i] += nums[index];
                
                if(Helper(nums,dp,avg,index+1,len))
                    return true;
                
                dp[i] -= nums[index];
            }
        }
        
        return false;
    }
}