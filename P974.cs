public class Solution {
    public int SubarraysDivByK(int[] A, int K) {
        var dp = new int[K];
        
        long sum = 0;
        
        dp[0] = 1;
        long result = 0;
        foreach(var item in A){
            sum+=item;
            var b = (sum%K+K)%K;
            result += dp[(int)b];
            dp[b]++;
        }
        
        return (int)result;
    }
}