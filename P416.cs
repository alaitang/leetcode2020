public class Solution {
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();
        if(sum % 2 ==1)
            return false;
        var dp = new bool[sum+1];
        
        dp[0] = true;
        
        foreach(var item in nums){
            for(int i = sum-item;i>=0;i--){
                if(dp[i] == true)
                    dp[i+item] = true;
            }
        }
        
        return dp[sum/2];
    }
}