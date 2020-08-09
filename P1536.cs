public class Solution {
    public int MinSwaps(int[][] grid) {
        var n = grid.Length;
        
        var dp = new int[n];
        for(int i = 0;i<n;i++){
            for(int j = n-1;j>=0;j--){
                if(grid[i][j] == 1)
                    break;
                dp[i]++;
            }
        }
        
        var result = 0;
        for(int i = 0;i<n-1;i++){
            var need = n-(i+1);
            var j = i;
            for(;j<n;j++){
                if(dp[j] >= need){
                    break;
                }
            }
            
            if(j == n)
                return -1;
            
            result += j-i;
            
            while(j > i){
                var t = dp[j];
                dp[j] = dp[j-1];
                dp[j-1] = t;
                j--;
            }
        }
        
        return result;
    }
}