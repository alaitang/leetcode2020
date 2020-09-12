public class Solution {
    public int LastStoneWeightII(int[] stones) {
        var sum = stones.Sum();
        
        var dp = new bool[sum+1];
        dp[0] = true;
        
        var result = sum;
        foreach(var item in stones){
            for(int i = sum-item;i>=0;i--){
                dp[i+item] |= dp[i];
                
                if(dp[i+item]){
                    result = Math.Min(result,Math.Abs(sum-(i+item)-(i+item)));
                }
            }
        }
        
        return result;
    }
}