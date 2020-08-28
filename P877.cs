public class Solution {
    public bool StoneGame(int[] piles) {
        var len = piles.Length;
        
        var dp = new int[len,len];
        var sums = new int[len];
        for(int i = 0;i<len;i++){
            dp[i,i] = piles[i];
            sums[i] = piles[i] + (i == 0 ? 0 : sums[i-1]);
            for(int j = i-1; j>=0;j--){
                
                var total = sums[i] - (j == 0 ? 0 : sums[j-1]);
                var left = piles[j] + (total - dp[j+1,i]); 
                var right = piles[i] + (total - dp[j,i-1]); 
                
                dp[j,i] = Math.Max(left,right);
            }
        }
        
        return dp[0,len-1] > (sums[len-1] - dp[0,len-1]);
    }
}