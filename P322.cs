public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount == 0)
            return 0;
        var dp = new int[amount+1];
        
        foreach(var c in coins){
            for(int i = 0;i<=amount-c;i++){
                if(i == 0 || dp[i] != 0){
                    if(dp[i+c] == 0 || dp[i+c] > dp[i]+1)
                        dp[i+c] = dp[i]+1;
                }
            }
        }
        
        return dp[amount] == 0? -1 : dp[amount];
    }
}