public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        var dp = new double[query_row+1];
        dp[0] = poured;
        for(int i = 1;i<=query_row;i++){
            
            var newdp = new double[query_row+1];
            for(int j = 0;j<=i;j++){
                newdp[j] += Math.Max(dp[j]-1,0)/2
                    + (j == 0? 0 : Math.Max(dp[j-1]-1,0)/2);
                
            }
            dp = newdp;
        }
        
        return Math.Min(1,dp[query_glass]);
    }
}