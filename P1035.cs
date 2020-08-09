public class Solution {
    public int MaxUncrossedLines(int[] A, int[] B) {
        var rows = A.Length;
        var cols = B.Length;
        
        var dp = new int[rows+1,cols+1];
        
        for(int i = 1;i<=rows;i++)
        {
            for(int j = 1;j<=cols;j++){
                dp[i,j] = Math.Max(dp[i-1,j],dp[i,j-1]);
                dp[i,j] = Math.Max(dp[i,j],dp[i-1,j-1] + (A[i-1]==B[j-1] ? 1 : 0));
            }
        }
        
        return dp[rows,cols];
    }
}