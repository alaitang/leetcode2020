public class Solution {
    public int NumTilings(int N) {
        var dp = new long[N+5,4];
        dp[0,3] = 1;
        for(int i = 1;i<=N;i++){
            
            dp[i+1,3] += dp[i-1,3];
            dp[i+1,3] %= 1000000007;
            
            dp[i,3] += dp[i-1,3] + dp[i-1,1] + dp[i-1,2];
            dp[i,3] %= 1000000007;
            
            dp[i+1,1] += dp[i,2] +dp[i-1,3];
            dp[i+1,1] %= 1000000007;
            
            dp[i+1,2] += dp[i,1] +dp[i-1,3];
            dp[i+1,2] %= 1000000007;
            
            //Console.WriteLine(dp[i,1]+","+dp[i,2] + ","+dp[i,3]);
        }
        
        return (int)dp[N,3];
    }
}