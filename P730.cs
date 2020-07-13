public class Solution {
    public int CountPalindromicSubsequences(string S) {
        var len = S.Length;
        
        var dp = new long[len,len];
        
        int M = 1000000007;
        
        for(int i = 0;i<len;i++){
            dp[i,i] = 1;
            var low = i;
            var high = i;
            for(int j = i-1;j>=0;j--){
                
                if(S[i] != S[j]){
                    dp[i,j] = dp[i-1,j] + dp[i,j+1] - dp[i-1,j+1];
                }else{
                    if(high == i){
                        dp[i,j] = i == j+1 ? 2 : (dp[i-1,j+1]*2+2);
                        high = j;
                    }else if(low == high){
                        dp[i,j] = dp[i-1,j+1]*2+1;
                    }else{
                        dp[i,j] = dp[i-1,j+1]*2 - (dp[high-1,low+1]);
                    }
                    low = j;
                }
                
                dp[i,j] = (dp[i,j]+M)%M;
            }
        }
        
        
        return (int)dp[len-1,0];
                                     
        
    }
}