public class Solution {
    public bool WinnerSquareGame(int n) {
        var dp = new bool[n+1];
        
        dp[0] = false;
        dp[1] = true;
        
        for(int i = 2;i<=n;i++){
            var s = Convert.ToInt32(Math.Sqrt(i));
            
            if(s*s == i){
                dp[i] = true;
            }
            
            for(int j = 1;!dp[i] && j*j <= i;j++){
                dp[i] |= !dp[i-j*j];
            }
        }
        
        return dp[n];
    }
}