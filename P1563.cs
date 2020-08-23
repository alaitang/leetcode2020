public class Solution {
    public int StoneGameV(int[] stoneValue) {
        var len = stoneValue.Length;
        var dp = new int[len,len];
        var sums = new int[len];
        
        for(int i = 0;i<len;i++)
        {
            sums[i] = stoneValue[i] + (i == 0 ? 0 : sums[i-1]);
            for(int j = i-1;j>=0;j--){
                
                for(int k = j;k<i;k++){
                    var max = 0;
                    var sumsleft = sums[k] - (j == 0? 0 : sums[j-1]);
                    
                    var sumsright = sums[i] - sums[k];
                    
                    if(sumsleft > sumsright){
                        
                        max = sumsright + dp[k+1,i];
                        
                    }else if(sumsleft < sumsright){
                        
                        max = sumsleft + dp[j,k];
                    }else{
                        max = Math.Max(dp[k+1,i],dp[j,k]) + sumsleft;
                    }
                    
                    dp[j,i] = Math.Max(max,dp[j,i]);
                }
                
            }
        }
        
        return dp[0,len-1];
        
    }
}