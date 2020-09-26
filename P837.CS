public class Solution {
    public double New21Game(int N, int K, int W) {
        var dp = new double[N+2];
        
        dp[0] = 1;
        dp[1] = -1;
        double currentR = 0;
        for(int i = 0;i<K;i++){
            currentR+=dp[i];
            var next = currentR/W;
            dp[i+1] += next;
            dp[Math.Min(i+W+1,N+1)]-=next;
        }
        
        double result = 0;
        
        for(int i = K;i<=N;i++){
            currentR+=dp[i];
            result += currentR;
        }
        
        return result;
    }
}