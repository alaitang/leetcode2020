public class Solution {
    public int GetMoneyAmount(int n) {
        if(n == 1)
            return 0;
        
        var dp = new int[n+1,n+1];
        dp[1,2] = 1;
        
        for(int i = 3;i<=n;i++){
            
            for(int j = i-1;j>0;j--){
                
                dp[j,i] = (i+j)*(i-j+1)/2;
                
                for(var k = j+1;k<i;k++){
                    var left = k-1 <= j ? 0 : dp[j,k-1];
                    var right = k+1 >= i ? 0 : dp[k+1,i];
                    dp[j,i] = Math.Min(k+Math.Max(left,right),dp[j,i]);
                }
            }
        }
        
        return dp[1,n];
    }
}